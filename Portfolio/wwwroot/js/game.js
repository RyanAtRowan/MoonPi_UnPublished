let audioEnabled = false; // Global flag to track if audio is enabled
let currentMusic;  // Global variable for music so it can be stopped when changing scenes

// ======================================================
// TitleScene: Handles the title screen where players select roles and start the game.
// ======================================================

class TitleScene extends Phaser.Scene {
    constructor() {
        super({ key: 'TitleScene' });  // Set scene key to 'TitleScene'
    }

    // ======================================================
    // Preload Method: Load all assets required for the title screen.
    // ======================================================
    preload() {
        // Preload background sprite sheet (10-frame animation)
        this.load.spritesheet('TitleBackground', '/Assets/HookOrBeHooked/TitleScene/Background/TitleBackground.png', {
            frameWidth: 800,      // Width of each frame
            frameHeight: 800,     // Height of each frame
            endFrame: 9           // 10-frame sprite sheet (0-9)
        });

        // Preload button images for role selection
        this.load.image('FishButton', '/Assets/HookOrBeHooked/TitleScene/Buttons/FishButton.png');
        this.load.image('FishButtonDisabled', '/Assets/HookOrBeHooked/TitleScene/Buttons/FishButtonDisabled.png');
        this.load.image('HookButton', '/Assets/HookOrBeHooked/TitleScene/Buttons/HookButton.png');
        this.load.image('HookButtonDisabled', '/Assets/HookOrBeHooked/TitleScene/Buttons/HookButtonDisabled.png');
        this.load.image('ButtonSelected', '/Assets/HookOrBeHooked/TitleScene/Buttons/ButtonSelected.png');

        // Preload sound related files
        this.load.audio('titleMusic', '/Assets/HookOrBeHooked/TitleScene/Sounds/waves_and_seagulls.wav');
        this.load.image('soundButton', '/Assets/HookOrBeHooked/TitleScene/Buttons/speaker.png');
        this.load.audio('buttonClick', '/Assets/HookOrBeHooked/TitleScene/Sounds/button_click.mp3');
    }

    // ======================================================
    // Create Method: Initialize all elements of the title screen.
    // ======================================================
    create() {
        console.log("Creating Title Screen...");

        // Set the player's role to 'spectator' by default and clear any stored role.
        this.playerRole = 'spectator';
        localStorage.removeItem('role');

        // Establish a SignalR connection to the game hub.
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")  // URL for the SignalR hub
            .build();

        // Start the SignalR connection and request current roles.
        this.connection.start().then(() => {
            console.log("Connected to SignalR for a new game");
            this.connection.invoke('SendCurrentRoles', this.connection.connectionId);  // Request role updates
        });

        // Create an animated background for the title screen.
        this.anims.create({
            key: 'backgroundAnim',
            frames: this.anims.generateFrameNumbers('TitleBackground', { start: 0, end: 9 }),
            frameRate: 5,   // Set animation speed (frames per second)
            repeat: -1      // Loop the animation indefinitely
        });

        // Add the animated background to the scene.
        let background = this.add.sprite(400, 400, 'TitleBackground').setOrigin(0.5, 0.5);
        background.play('backgroundAnim');  // Play the background animation

        // Create the role selection buttons (Fish and Hook).
        this.createRoleButtons();

        // Add Sound Button
        if (!audioEnabled) {
            let soundButton = this.add.image(700, 100, 'soundButton').setInteractive();

            soundButton.on('pointerdown', () => {
                if (!audioEnabled) {
                    audioEnabled = true; // Set the flag to true
                    this.playMusic('titleMusic'); // Play music for title scene

                    soundButton.setVisible(false);
                }
            });
        }
        else {
            this.playMusic('titleMusic');
        }



        // ======================================================
        // SignalR Event Listeners for Role Updates and Game Start
        // ======================================================

        // Listen for role updates and update buttons accordingly.
        this.connection.on("UpdateRoles", (fishRole, hookRole) => {
            this.updateRoleButtons(fishRole, hookRole);  // Update buttons based on available roles
        });

        // Listen for the "StartGame" event and transition to the GameScene.
        this.connection.on("StartGame", () => {
            console.log("Initializing GameScene...");
            this.scene.start('GameScene');  // Transition to the GameScene
        });

        // Listen for the "HowToPlay" event and transition to the HowToPlayScene
        this.connection.on("HowToPlay", () => {
            this.scene.start('HowToPlayScene');
        });
    }

    // Play music
    playMusic(key) {
        if (audioEnabled) {
            // Stop any current music
            if (currentMusic) {
                currentMusic.stop();
            }

            // Play new music for the scene
            currentMusic = this.sound.add(key, { loop: true });
            currentMusic.play();
        }
    }


    // ======================================================
    // Create Role Buttons: Creates and initializes Fish and Hook buttons.
    // ======================================================
    createRoleButtons() {
        // Create Fish role button and set up interaction.
        this.fishButton = this.add.image(200, 700, 'FishButton')
            .setInteractive()  // Make the button interactive (clickable)
            .on('pointerdown', () => {  // When the button is clicked, assign the Fish role
                this.sound.play('buttonClick');
                this.connection.invoke('AssignRole', 'fish', this.connection.connectionId);
            });

        // Create Hook role button and set up interaction.
        this.hookButton = this.add.image(600, 700, 'HookButton')
            .setInteractive()  // Make the button interactive (clickable)
            .on('pointerdown', () => {  // When the button is clicked, assign the Hook role
                this.sound.play('buttonClick');
                this.connection.invoke('AssignRole', 'hook', this.connection.connectionId);
            });
    }

    // ======================================================
    // Update Role Buttons: Updates button states based on role availability.
    // ======================================================
    updateRoleButtons(fishRole, hookRole, spectators) {
        const myConnectionId = this.connection.connectionId;  // Get current player's connection ID

        // ======================================================
        // Fish Button Logic: Update based on Fish role status.
        // ======================================================
        if (fishRole === null) {
            // If no one has taken the Fish role, set the button to available and interactive.
            this.fishButton.setTexture('FishButton').setInteractive();
        } else if (fishRole === myConnectionId) {
            // If the current player has selected the Fish role, disable the button and mark it as selected.
            this.fishButton.setTexture('ButtonSelected').disableInteractive();
            localStorage.setItem('role', 'fish');  // Store role in localStorage
        } else {
            // If someone else has selected the Fish role, disable the button.
            this.fishButton.setTexture('FishButtonDisabled').disableInteractive();
        }

        // ======================================================
        // Hook Button Logic: Update based on Hook role status.
        // ======================================================
        if (hookRole === null) {
            // If no one has taken the Hook role, set the button to available and interactive.
            this.hookButton.setTexture('HookButton').setInteractive();
        } else if (hookRole === myConnectionId) {
            // If the current player has selected the Hook role, disable the button and mark it as selected.
            this.hookButton.setTexture('ButtonSelected').disableInteractive();
            localStorage.setItem('role', 'hook');  // Store role in localStorage
        } else {
            // If someone else has selected the Hook role, disable the button.
            this.hookButton.setTexture('HookButtonDisabled').disableInteractive();
        }

        // ======================================================
        // Spectator Logic: If both roles are taken, assign the player as a spectator.
        // ======================================================
        if (fishRole !== null && hookRole !== null && !spectators.includes(myConnectionId)) {
            localStorage.setItem('role', 'spectator');  // Set the player as a spectator in localStorage
        }
    }
}

// ======================================================
// GameScene: Core gameplay scene where the player takes on the role of Fish or Hook.
// ======================================================

class GameScene extends Phaser.Scene {
    constructor() {
        super({ key: 'GameScene' });  // Set scene key to 'GameScene'

        // Initialize important game objects and variables
        this.fish = null;
        this.hook = null;
        this.hookSpeed = 170;
        this.trashGroup = null;
        this.spectator = false;  // Default spectator role

        // Trash Debuff variables
        this.timeDebuff = -1;
        this.isDebuffed = false;

        // Track the last known position of the Fish and Hook to reduce unnecessary updates
        this.fishLastPosition = { x: 0, y: 0 };
        this.hookLastPosition = { x: 0, y: 0 };

        // Initialize timer text
        this.timerText = null;
        this.timeLeft = 30;

        this.trashTimer = 0;  // Timer for generating trash
        this.trashInterval = 2000;  // Time interval between trash generation (in milliseconds)


    }

    // ======================================================
    // Preload Method: Load all assets required for the game scene.
    // ======================================================
    preload() {
        // Preload background image
        this.load.image('GameBackground', '/Assets/HookOrBeHooked/GameScene/Background/GameBackground.png');

        // Preload Trash sound
        this.load.audio('trashSplat', '/Assets/HookOrBeHooked/GameScene/Sounds/splat.wav');

        // Preload Fish and Hook sprite sheets (4-frame animations)
        this.load.spritesheet('Fish', '/Assets/HookOrBeHooked/GameScene/Fish/Fish.png', {
            frameWidth: 96,
            frameHeight: 90,
            endFrame: 3
        });

        this.load.spritesheet('Hook', '/Assets/HookOrBeHooked/GameScene/Hook/Hook.png', {
            frameWidth: 48,
            frameHeight: 90,
            endFrame: 3
        });

        // Preload Trash sprite sheet (5 frames)
        this.load.spritesheet('Trash', '/Assets/HookOrBeHooked/GameScene/Trash/Trash.png', {
            frameWidth: 102,
            frameHeight: 48,
            endFrame: 4
        });
    }

    // ======================================================
    // Create Method: Initialize all game objects, listeners, and events.
    // ======================================================
    create() {
        console.log("Creating Scene: GameScene...");
        // Reset Timer from previous games
        this.timeLeft = 30;


        // Retrieve role from localStorage or default to 'spectator'
        this.playerRole = localStorage.getItem('role') || 'spectator';

        // Setup SignalR connection to the game hub
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")
            .build();

        // Start SignalR connection and set up event listeners
        this.connection.start().then(() => {
            console.log("Connected to SignalR");

            // Listen for position updates from other players
            this.connection.on("ReceivePosition", (role, x, y) => {
                if (role === 'fish') {
                    this.fish.setPosition(x, y);  // Update Fish position
                } else if (role === 'hook') {
                    this.hook.setPosition(x, y);  // Update Hook position
                }
            });

            // Listen for role updates for spectators
            this.connection.on("UpdateRoles", (fishRole, hookRole, spectators) => {
                const myConnectionId = this.connection.connectionId;
                if (!spectators.includes(myConnectionId)) {
                    // If the player is a spectator, allow them to throw trash
                    this.input.on('pointerdown', this.spawnTrash, this);
                }
            });
        });

        // ======================================================
        // Create Game Elements (Background, Fish, Hook, Trash)
        // ======================================================

        // Create the background image
        this.add.image(400, 400, 'GameBackground').setOrigin(0.5, 0.5);

        // Create Fish and Hook animations
        this.anims.create({
            key: 'swim',
            frames: this.anims.generateFrameNumbers('Fish', { start: 0, end: 3 }),
            frameRate: 5,
            repeat: -1  // Loop the animation
        });

        this.anims.create({
            key: 'hookMove',
            frames: this.anims.generateFrameNumbers('Hook', { start: 0, end: 3 }),
            frameRate: 5,
            repeat: -1  // Loop the animation
        });

        // Create Trash animation
        this.anims.create({
            key: 'trashMove',
            frames: this.anims.generateFrameNumbers('Trash', { start: 0, end: 4 }),
            frameRate: 5,
            repeat: -1  // Loop the animation
        });

        // Create Fish and Hook sprites with initial positions and animations
        this.fish = this.physics.add.sprite(100, 400, 'Fish').setScale(1);
        this.hook = this.physics.add.sprite(700, 400, 'Hook').setScale(1);

        // Set default positions for Fish and Hook at game start
        this.fish.setPosition(100, 400);
        this.hook.setPosition(700, 400);

        // Reset target positions
        this.fishTarget = { x: 100, y: 400 };
        this.hookTarget = { x: 700, y: 400 };

        this.fishLastPosition = { x: 100, y: 400 };  // Default position for Fish
        this.hookLastPosition = { x: 700, y: 400 };  // Default position for Hook


        // Adjust hook and fish collider
        this.hook.body.setSize(this.hook.width - 40, this.hook.height - 40);
        this.fish.body.setSize(this.fish.width - 20, this.fish.height - 20);

        // Set the world bounds to constrain Fish and Hook within the canvas (800x800)
        this.physics.world.setBounds(0, 0, 800, 800);
        this.fish.setCollideWorldBounds(true);  // Constrain Fish
        this.hook.setCollideWorldBounds(true);  // Constrain Hook

        // Play Fish and Hook animations
        this.fish.play('swim');
        this.hook.play('hookMove');

        // Create the Trash group
        this.trashGroup = this.physics.add.group();

        // ======================================================
        // Input Handling and Collision Detection
        // ======================================================

        // Setup input handling for Fish and Hook movement
        this.input.on('pointermove', this.setTargetPosition, this);

        // Enable collision detection between Hook, Fish, and Trash

        // Hook catches Fish
        this.physics.add.overlap(this.hook, this.fish, this.hookWins, null, this);  

        // Hook hits Trash (Loses Game: OLD FEATURE)
        //this.physics.add.overlap(this.hook, this.trashGroup, this.fishWins, null, this);

        // Hook hits Trash (Slows down Hook)
        this.physics.add.overlap(this.hook, this.trashGroup, this.debuffHook, null, this);

        // ======================================================
        // SignalR Event Listeners for Win Conditions and Trash Spawning
        // ======================================================

        // Hook Wins Event: Transition to HookWinsScene when Hook wins
        this.connection.on("HookWins", () => {
            this.connection.stop().then(() => {
                this.resetHook();
                this.playerRole = 'spectator';
                localStorage.removeItem('role');  // Clear stored role after game end
                this.scene.start('HookWinsScene');  // Transition to HookWinsScene
            }).catch((error) => console.error("Error stopping connection:", error));
        });

        // Fish Wins Event: Transition to FishWinsScene when Fish wins
        this.connection.on("FishWins", () => {
            this.connection.stop().then(() => {
                this.resetHook();
                this.playerRole = 'spectator';
                localStorage.removeItem('role');  // Clear stored role after game end
                this.scene.start('FishWinsScene');  // Transition to FishWinsScene
            }).catch((error) => console.error("Error stopping connection:", error));
        });

        // Clear localStorage when requested
        this.connection.on("ClearLocalStorage", () => {
            localStorage.removeItem('role');
        });

        // Listen for trash spawning from other spectators
        this.connection.on("spawnTrashEvent", (size, speed, y) => {
                this.spawnTrash(size, speed, y);
        });

        // Spectators can generate trash
        if (this.playerRole === 'spectator') {
            this.input.on('pointerdown', this.generateTrashData, this);
        }

        // Set up timer text
        this.timerText = this.add.text(400, 50, 'Time: 30', {
            fontSize: '32px',
            fill: '#ffffff'
        }).setOrigin(0.5, 0.5);

        // Start the local timer
        this.time.addEvent({
            delay: 1000,                // 1 second delay
            callback: this.updateTimer,  // Function to call every second
            callbackScope: this,         // Scope to run the callback in
            loop: true                   // Repeat every second
        });
    }
    // ======================================================
    // Timer Methods
    // ======================================================

    updateTimer() {
        // Decrement the time
        this.timeLeft--;

        // Update the timer text display
        this.timerText.setText('Time: ' + this.timeLeft);

        // If the timer hits 0, check the roles and declare the fish winner
        if (this.timeLeft <= 0) {
            this.timeLeft = 30;
            this.connection.invoke("ResetRoles").then(() => {
                this.connection.invoke("FishWins");
            });
        }
    }



    // ======================================================
    // Custom Game Logic Methods
    // ======================================================

    // Hook has collided with trash, slow speed!
    debuffHook() {
        // Sets time to be debuffed to 2 seconds
        this.timeDebuff = 2000;

        // Sets Debuff Boolean
        this.isDebuffed = true;
    }

    resetHook() {
        this.isDebuffed = false;
        this.hookSpeed = 180;
    }

    // Handle the input for setting the target position of Fish or Hook
    setTargetPosition(pointer) {
        if (this.playerRole === 'fish') {
            this.fishTarget = { x: pointer.x, y: pointer.y };
        } else if (this.playerRole === 'hook') {
            this.hookTarget = { x: pointer.x, y: pointer.y };
        }
    }

    // Move the object (Fish or Hook) toward the target position
    moveToTarget(object, target, speed) {
        if (!target) return;  // Skip if no target is set
        const distance = Phaser.Math.Distance.Between(object.x, object.y, target.x, target.y);
        if (distance > 10) {
            this.physics.moveToObject(object, target, speed);  // Move toward target
        } else {
            object.body.setVelocity(0, 0);  // Stop moving when close enough
        }
    }

    // Broadcast the updated position of Fish or Hook to the server
    broadcastPosition(role, object) {
        if (role === 'fish' && (object.x !== this.fishLastPosition.x || object.y !== this.fishLastPosition.y)) {
            this.connection.invoke('UpdatePosition', 'fish', object.x, object.y);
            this.fishLastPosition = { x: object.x, y: object.y };  // Update last known position
        } else if (role === 'hook' && (object.x !== this.hookLastPosition.x || object.y !== this.hookLastPosition.y)) {
            this.connection.invoke('UpdatePosition', 'hook', object.x, object.y);
            this.hookLastPosition = { x: object.x, y: object.y };  // Update last known position
        }
    }

    // Hook Wins: Handle when Hook catches Fish
    hookWins() {
        this.timeLeft = 30;
        this.connection.invoke("ResetRoles").then(() => {
            this.connection.invoke("HookWins");
        });
    }

    // Fish Wins: Handle when Hook hits Trash (Fish wins)
    fishWins() {
        this.timeLeft = 30;
        this.connection.invoke("ResetRoles").then(() => {
            this.connection.invoke("FishWins");
        });
    }

    // Generate trash data when spectators click/tap
    generateTrashData(pointer) {
        let y = pointer.y;
        let size = Phaser.Math.Between(1, 5);  // Generate random size for trash
        let speed = Phaser.Math.Between(70, 300);  // Generate random speed for trash

        this.connection.invoke('CreateTrash', size, speed, y);  // Send trash data to the server
    }

    // Spawn trash for spectators
    spawnTrash(size, speed, y) {
        // Check if there are spectators for automation
            if (!this.spectatorsPresent) {
                size = 1 + (size / 10);  // Adjust size to be within 1.0 and 1.5
                let trash = this.trashGroup.create(0, y, 'Trash').setScale(size);  // Create trash at the given Y position
                trash.setVelocityX(speed);  // Move the trash from left to right at the random speed
                trash.anims.play('trashMove', true);  // Play trash animation
                this.sound.play('trashSplat');
            }
    }

    // ======================================================
    // Update Method: Runs every frame
    // ======================================================
    update(time, delta) {
        // Debuff Checks
        if (this.isDebuffed === true) {
            // Decrement Time by time passed since last frame
            this.timeDebuff -= delta;

            // If Debuff time is 0 or less, turn off debuff
            if (this.timeDebuff <= 0) {
                // Turn off Debuff
                this.isDebuffed = false;

                // Set Speed Back to Normal
                this.hookSpeed = 180;
            }
            else {
                // Debuff is active, adjust speed
                this.hookSpeed = 70;
            }
        }


        // Check if trash has moved off-screen and destroy it
        this.trashGroup.children.each(trash => {
            if (trash.x > 800) {  // If trash moves beyond the canvas width (800)
                trash.destroy();  // Destroy the trash
            }
        });

        // Increment the trash timer by delta time (time passed since last frame)
        this.trashTimer += delta;

        // If the timer exceeds the interval, generate trash and reset the timer
        if (this.trashTimer >= this.trashInterval) {
            // Call generateTrashData to generate trash every second
            this.generateTrashData({ y: Phaser.Math.Between(100, 700) });  // Random Y value for demo
            this.trashTimer = 0;  // Reset the timer
        }

        // Continuously move Fish or Hook towards their target positions and broadcast updates
        if (this.playerRole === 'fish') {
            this.moveToTarget(this.fish, this.fishTarget, 230);  // Move Fish
            this.broadcastPosition('fish', this.fish);  // Send Fish position
        } else if (this.playerRole === 'hook') {
            this.moveToTarget(this.hook, this.hookTarget, this.hookSpeed);  // Move Hook
            this.broadcastPosition('hook', this.hook);  // Send Hook position
        }
    }
}

// ======================================================
// HowToPlayScene: Scene displayed before game start.
// ======================================================

class HowToPlayScene extends Phaser.Scene {
    constructor() {
        super({ key: 'HowToPlayScene' });  // Set scene key to 'FishWinsScene'
    }

    // ======================================================
    // Preload Method: Load all assets required for the victory scene.
    // ======================================================
    preload() {
        // Preload the background image for instructions
        this.load.image('HowToPlayBackground', '/Assets/HookOrBeHooked/HowToPlay/HowToPlay.png');

        // Preload gameplay music
        this.load.audio('gameMusic', '/Assets/HookOrBeHooked/HowToPlay/Sounds/water-game-music.wav')
    }

    // ======================================================
    // Create Method: Initialize the how-to-play scene elements.
    // ======================================================
    create() {
        // Add the HowToPlay background image to the center of the scene
        this.add.image(400, 400, 'HowToPlayBackground').setOrigin(0.5, 0.5);

        if (audioEnabled) {
            this.playMusic('gameMusic');  // Play the game music
        }

        // Set a timed event to automatically transition to the GameScene after 5 seconds
        this.time.delayedCall(5000, () => {
            // Move to GameScene
            this.scene.start('GameScene');
        });
    }

    // Play music
    playMusic(key) {
        if (audioEnabled) {
            // Stop any current music
            if (currentMusic) {
                currentMusic.stop();
            }

            // Play new music for the scene
            currentMusic = this.sound.add(key, { loop: true, volume: .5 });
            currentMusic.play();
        }
    }
}


// ======================================================
// FishWinsScene: Scene displayed when the Fish wins the game.
// ======================================================

class FishWinsScene extends Phaser.Scene {
    constructor() {
        super({ key: 'FishWinsScene' });  // Set scene key to 'FishWinsScene'
    }

    // ======================================================
    // Preload Method: Load all assets required for the victory scene.
    // ======================================================
    preload() {
        // Preload the background image for Fish's victory
        this.load.image('FishWinsBackground', '/Assets/HookOrBeHooked/VictoryScene/FishWins.png');

        // PreLoad the Victory Music
        this.load.audio('fishVictory', '/Assets/HookOrBeHooked/VictoryScene/Sounds/winner.wav');
    }

    // ======================================================
    // Create Method: Initialize the victory scene elements.
    // ======================================================
    create() {
        // Add the FishWins background image to the center of the scene
        this.add.image(400, 400, 'FishWinsBackground').setOrigin(0.5, 0.5);

        if (audioEnabled) {
            this.playMusic('fishVictory');  // Play the game music
        }

        // Set a timed event to automatically transition back to the TitleScene after 5 seconds
        this.time.delayedCall(5000, () => {
            this.scene.start('TitleScene');  // Transition back to the TitleScene
        });
    }

    playMusic(key) {
        if (audioEnabled) {
            // Stop any current music
            if (currentMusic) {
                currentMusic.stop();
            }

            // Play new music for the scene
            currentMusic = this.sound.add(key, { loop: true });
            currentMusic.play();
        }
    }
}

// ======================================================
// HookWinsScene: Scene displayed when the Hook wins the game.
// ======================================================

class HookWinsScene extends Phaser.Scene {
    constructor() {
        super({ key: 'HookWinsScene' });  // Set scene key to 'HookWinsScene'
    }

    // ======================================================
    // Preload Method: Load all assets required for the victory scene.
    // ======================================================
    preload() {
        // Preload the background image for Hook's victory
        this.load.image('HookWinsBackground', '/Assets/HookOrBeHooked/VictoryScene/HookWins.png');

        // PreLoad the Victory Music
        this.load.audio('hookVictory', '/Assets/HookOrBeHooked/VictoryScene/Sounds/winner.wav');
    }

    // ======================================================
    // Create Method: Initialize the victory scene elements.
    // ======================================================
    create() {
        // Add the HookWins background image to the center of the scene
        this.add.image(400, 400, 'HookWinsBackground').setOrigin(0.5, 0.5);

        if (audioEnabled) {
            this.playMusic('hookVictory');  // Play the game music
        }

        // Set a timed event to automatically transition back to the TitleScene after 5 seconds
        this.time.delayedCall(5000, () => {
            this.scene.start('TitleScene');  // Transition back to the TitleScene
        });
    }

    playMusic(key) {
        if (audioEnabled) {
            // Stop any current music
            if (currentMusic) {
                currentMusic.stop();
            }

            // Play new music for the scene
            currentMusic = this.sound.add(key, { loop: true });
            currentMusic.play();
        }
    }
}


// ======================================================
// SignalR Hub Connection Setup
// ======================================================

// Establish a connection to the SignalR hub using a SignalR HubConnectionBuilder.
// The connection is built to communicate with the "/gameHub" URL, which manages game events across clients.
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameHub")
    .build();

// Start the SignalR connection
connection.start()
    .then(() => console.log("SignalR Connected"))  // Logs success message upon connection establishment
    .catch(err => console.error("SignalR Error: " + err));  // Logs an error if the connection fails

// ======================================================
// SignalR Game State Communication (example methods)
// ======================================================

// Function to send the game state to the server (invoked from within the game logic).
// gameState: An object or data structure representing the current state of the game.
function sendGameUpdate(gameState) {
    connection.invoke("SendGameUpdate", gameState)
        .catch(err => console.error(err.toString()));  // Logs an error if sending fails
}

// Set up a listener to receive updates from other players.
// The "ReceiveGameUpdate" event is triggered when the server sends a game update.
connection.on("ReceiveGameUpdate", function (gameState) {
    console.log("Received Game Update: ", gameState);  // Logs the received game state for debugging
    // Additional logic can be placed here to handle the incoming gameState and update the game accordingly.
});

// ======================================================
// Phaser.js Game Configuration
// ======================================================

var config = {
    type: Phaser.AUTO,  // Phaser will automatically decide the best rendering method (WebGL or Canvas)
    width: 800,         // Base width of the game canvas
    height: 800,        // Base height of the game canvas

    // Scale configuration: Ensures the game scales to fit the screen and centers horizontally.
    scale: {
        mode: Phaser.Scale.FIT,               // Scales the game to fit the screen
        autoCenter: Phaser.Scale.CENTER_HORIZONTALLY,  // Centers the game canvas horizontally
        parent: 'gameContainer'               // Parent container where the game canvas will be rendered
    },

    // Physics configuration: Using Arcade Physics with no gravity since this is a top-down style game.
    physics: {
        default: 'arcade',
        arcade: {
            gravity: { y: 0 },  // No gravity for objects
            debug: false        // Physics debugging turned off (set to true for visual debugging)
        }
    },

    // Scenes included in the game: Defines the order in which scenes are loaded and available.
    scene: [TitleScene, GameScene, HookWinsScene, FishWinsScene, HowToPlayScene]
};

// ======================================================
// Initialize Phaser Game Instance
// ======================================================

var game = new Phaser.Game(config);  // Initializes the Phaser game with the defined configuration