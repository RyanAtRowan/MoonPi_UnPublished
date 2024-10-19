class FishWinsScene extends Phaser.Scene {
    constructor() {
        super({ key: 'FishWinsScene' });
    }

    preload() {
        // Preload the HookWins background image
        this.load.image('FishWinsBackground', '/Assets/HookOrBeHooked/VictoryScene/FishWins.png');
    }

    create() {
        // Add the HookWins background image to the scene
        this.add.image(400, 400, 'FishWinsBackground').setOrigin(0.5, 0.5);

        // Set a timed event to transition back to the TitleScene after 5 seconds
        this.time.delayedCall(5000, () => {
            this.scene.start('TitleScene');  // Transition back to the TitleScene
        });
    }
}

class HookWinsScene extends Phaser.Scene {
    constructor() {
        super({ key: 'HookWinsScene' });
    }

    preload() {
        // Preload the HookWins background image
        this.load.image('HookWinsBackground', '/Assets/HookOrBeHooked/VictoryScene/HookWins.png');
    }

    create() {
        // Add the HookWins background image to the scene
        this.add.image(400, 400, 'HookWinsBackground').setOrigin(0.5, 0.5);

        // Set a timed event to transition back to the TitleScene after 5 seconds
        this.time.delayedCall(5000, () => {
            this.scene.start('TitleScene');  // Transition back to the TitleScene
        });
    }
}


class GameScene extends Phaser.Scene {
    constructor() {
        super({ key: 'GameScene' });

        this.fish = null;
        this.hook = null;
        this.trashGroup = null;
        this.spectator = false;  // Default spectator role

        this.fishLastPosition = { x: 0, y: 0 };  // To track the last known position of the Fish
        this.hookLastPosition = { x: 0, y: 0 };  // To track the last known position of the Hook
    }

    preload() {
        // Preload the background image
        this.load.image('GameBackground', '/Assets/HookOrBeHooked/GameScene/Background/GameBackground.png');

        // Preload Fish and Hook sprite sheets (4 frames each)
        this.load.spritesheet('Fish', '/Assets/HookOrBeHooked/GameScene/Fish/Fish.png', {
            frameWidth: 96,
            frameHeight: 90,
            endFrame: 3
        });

        this.load.spritesheet('Hook', '/Assets/HookOrBeHooked/GameScene/Hook/Hook.png', {
            frameWidth: 96,
            frameHeight: 90,
            endFrame: 3
        });

        // Preload the Trash sprite sheet (5 frames)
        this.load.spritesheet('Trash', '/Assets/HookOrBeHooked/GameScene/Trash/Trash.png', {
            frameWidth: 96,
            frameHeight: 90,
            endFrame: 4
        });
    }

    create() {
        console.log("Creating Scene: GameScene...");
        // Retrieve role from localStorage
        this.playerRole = localStorage.getItem('role') || 'spectator';

        // Setup SignalR connection
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")
            .build();

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

            // Listen for spectator role updates
            this.connection.on("UpdateRoles", (fishRole, hookRole, spectators) => {
                const myConnectionId = this.connection.connectionId;
                if (!spectators.includes(myConnectionId)) {
                    // Spectators can throw trash
                    this.input.on('pointerdown', this.spawnTrash, this);
                }
            });
        });

        // Create the Trash group
        this.trashGroup = this.physics.add.group();

        // Add the background image
        this.add.image(400, 400, 'GameBackground').setOrigin(0.5, 0.5);

        // Create Fish and Hook animations
        this.anims.create({
            key: 'swim',
            frames: this.anims.generateFrameNumbers('Fish', { start: 0, end: 3 }),
            frameRate: 5,
            repeat: -1
        });

        this.anims.create({
            key: 'hookMove',
            frames: this.anims.generateFrameNumbers('Hook', { start: 0, end: 3 }),
            frameRate: 5,
            repeat: -1
        });

        // Create Trash animation
        this.anims.create({
            key: 'trashMove',
            frames: this.anims.generateFrameNumbers('Trash', { start: 0, end: 4 }),
            frameRate: 5,
            repeat: -1
        });

        // Create Fish and Hook sprites with animations
        this.fish = this.physics.add.sprite(100, 400, 'Fish').setScale(1);
        this.hook = this.physics.add.sprite(700, 400, 'Hook').setScale(1);

        // Set world bounds to constrain the Fish and Hook within the canvas (800x800)
        this.physics.world.setBounds(0, 0, 800, 800);

        // Constrain Fish and Hook to the world bounds
        console.log("Setting up boundaries... ");
        this.fish.setCollideWorldBounds(true);
        this.hook.setCollideWorldBounds(true);

        // Play the animations
        console.log("Setting up animations... ");
        this.fish.play('swim');
        this.hook.play('hookMove');

        // Create the Trash group
        this.trashGroup = this.physics.add.group();

        // Setup input handling for both Fish and Hook 
        console.log("Setting up input handling... ");
        this.input.on('pointermove', this.setTargetPosition, this);

        // Enable collision detection between Hook, Fish, and Trash
        console.log("Setting up collision... ");
        this.physics.add.overlap(this.hook, this.fish, this.hookWins, null, this);
        this.physics.add.overlap(this.hook, this.trashGroup, this.fishWins, null, this);

        // Listen for Hook Wins Event
        this.connection.on("HookWins", () => {
            // Stop the SignalR connection before transitioning
            this.connection.stop().then(() => {
                this.playerRole = 'spectator';
                localStorage.removeItem('role');  // Clear stored role after game end
                this.scene.start('HookWinsScene');  // Go back to the title scene
            }).catch((error) => {
                console.error("Error stopping connection:", error);
            });
        });

        // Listen for Fish Wins Event
        this.connection.on("FishWins", () => {
            // Stop the SignalR connection before transitioning
            this.connection.stop().then(() => {
                this.playerRole = 'spectator';
                localStorage.removeItem('role');  // Clear stored role after game end
                this.scene.start('FishWinsScene');  // Go back to the title scene
            }).catch((error) => {
                console.error("Error stopping connection:", error);
            });
        });

        this.connection.on("ClearLocalStorage", () => {
            console.log("Clearing local storage...");
            localStorage.removeItem('role');  // Clear the stored role
        });

        this.connection.on("spawnTrashEvent", (size, speed, y) => {
            this.spawnTrash(size, speed, y);
        });

        if (this.playerRole === 'spectator') {
            this.input.on('pointerdown', this.generateTrashData, this)
        }
    }

    // Store the target position on click
    setTargetPosition(pointer) {
        if (this.playerRole === 'fish') {
            this.fishTarget = { x: pointer.x, y: pointer.y };
        } else if (this.playerRole === 'hook') {
            this.hookTarget = { x: pointer.x, y: pointer.y };
        }
    }

    // Move the object and stop when it reaches the target
    moveToTarget(object, target, speed) {
        if (!target) return;  // If target hasn't been set yet, skip
        const distance = Phaser.Math.Distance.Between(object.x, object.y, target.x, target.y);
        if (distance > 10) {
            this.physics.moveToObject(object, target, speed);
        } else {
            object.body.setVelocity(0, 0);  // Stop moving when close enough
        }
    }

    // Broadcast the position of the object (Fish or Hook) to the server
    broadcastPosition(role, object) {
        // Only send the position if it has changed since the last frame
        if (role === 'fish' && (object.x !== this.fishLastPosition.x || object.y !== this.fishLastPosition.y)) {
            this.connection.invoke('UpdatePosition', 'fish', object.x, object.y);
            this.fishLastPosition = { x: object.x, y: object.y };  // Update last position
        } else if (role === 'hook' && (object.x !== this.hookLastPosition.x || object.y !== this.hookLastPosition.y)) {
            this.connection.invoke('UpdatePosition', 'hook', object.x, object.y);
            this.hookLastPosition = { x: object.x, y: object.y };  // Update last position
        }
    }

    // Collision detection: Hook catches Fish
    hookWins() {
        console.log("Resetting Roles...");
        this.connection.invoke("ResetRoles").then(() => {
            // Transition to HookWinsScene
            this.connection.invoke("HookWins");
        });
    }

    // Collision detection: Hook hits Trash
    fishWins() {
        console.log("Resetting Roles...");
        this.connection.invoke("ResetRoles").then(() => {
            // Transition to HookWinsScene
            this.connection.invoke("FishWins");
        });
    }

    generateTrashData(pointer) {
        let y = pointer.y

        // Generate a random size between 1 and 5 (to be within 1.0 and 1.5)
        let size = Phaser.Math.Between(1, 5);

        // Generate a random speed within a range
        let speed = Phaser.Math.Between(70, 300);

        this.connection.invoke('CreateTrash', size, speed, y)
    }

    // Spectator ability to throw trash
    spawnTrash(size, speed, y) {
        // Adjusts size to be a number between 1 and 1.5
        size = 1 + (size / 10);

        // Create trash at the given Y position
        let trash = this.trashGroup.create(0, y, 'Trash').setScale(size);

        // Move the trash from left to right at the random speed
        trash.setVelocityX(speed);

        trash.anims.play('trashMove', true);
    }

    // Update method runs every frame
    update() {
        // Call this for every object in the trash group
        this.trashGroup.children.each(function (trash) {
            // If the trash moves off the right side of the screen, destroy it
            if (trash.x > 800) {  // Assuming the canvas width is 800
                trash.destroy();  // Destroy the trash once it moves off-screen
            }
        }, this);

        if (this.playerRole === 'fish') {
            this.moveToTarget(this.fish, this.fishTarget, 200);
            this.broadcastPosition('fish', this.fish);  // Continuously send the Fish position
        } else if (this.playerRole === 'hook') {
            this.moveToTarget(this.hook, this.hookTarget, 170);
            this.broadcastPosition('hook', this.hook);  // Continuously send the Hook position
        }
    }
}



// Title Screen Logic
class TitleScene extends Phaser.Scene {
    constructor() {
        super({ key: 'TitleScene' });
    }


    preload() {
        this.load.spritesheet('TitleBackground', '/Assets/HookOrBeHooked/TitleScene/Background/TitleBackground.png', {
            frameWidth: 800,
            frameHeight: 800,
            endFrame: 9  // Since it's a 10-frame sprite sheet (0-9)
        });


        // Preload button images
        this.load.image('FishButton', '/Assets/HookOrBeHooked/TitleScene/Buttons/FishButton.png');
        this.load.image('FishButtonDisabled', '/Assets/HookOrBeHooked/TitleScene/Buttons/FishButtonDisabled.png');
        this.load.image('HookButton', '/Assets/HookOrBeHooked/TitleScene/Buttons/HookButton.png');
        this.load.image('HookButtonDisabled', '/Assets/HookOrBeHooked/TitleScene/Buttons/HookButtonDisabled.png');
        this.load.image('ButtonSelected', '/Assets/HookOrBeHooked/TitleScene/Buttons/ButtonSelected.png');
    }

    create() {

        console.log("Creating Title Screen...");
        // Retrieve role from localStorage
        this.playerRole = 'spectator';
        localStorage.removeItem('role');

        //this.playerRole = localStorage.getItem('role') || 'spectator';

        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")
            .build();

        this.connection.start().then(() => {
            console.log("Connected to SignalR for a new game");

            // Request current roles when the connection is established
            this.connection.invoke('SendCurrentRoles', this.connection.connectionId);
        });

        // Create the background animation
        this.anims.create({
            key: 'backgroundAnim',
            frames: this.anims.generateFrameNumbers('TitleBackground', { start: 0, end: 9 }),
            frameRate: 5,  // Adjust the frame rate as needed
            repeat: -1  // Loop the animation
        });

        // Add the animated background
        let background = this.add.sprite(400, 400, 'TitleBackground').setOrigin(0.5, 0.5);
        background.play('backgroundAnim');

        // Buttons for role selection
        this.createRoleButtons();

        // Listen for role updates
        this.connection.on("UpdateRoles", (fishRole, hookRole) => {
            this.updateRoleButtons(fishRole, hookRole);
        });

        // Listen for game start
        this.connection.on("StartGame", () => {
            console.log("Initializing GameScene...");
            this.scene.start('GameScene'); // Transition to the game scene
        });
    }

    createRoleButtons() {
        // Create Fish button
        this.fishButton = this.add.image(200, 700, 'FishButton')
            .setInteractive()
            .on('pointerdown', () => {
                this.connection.invoke('AssignRole', 'fish', this.connection.connectionId);
            });

        // Create Hook button
        this.hookButton = this.add.image(600, 700, 'HookButton')
            .setInteractive()
            .on('pointerdown', () => {
                this.connection.invoke('AssignRole', 'hook', this.connection.connectionId);
            });
    }

    updateRoleButtons(fishRole, hookRole, spectators) {
        const myConnectionId = this.connection.connectionId;

        // Fish button logic
        if (fishRole === null) {
            this.fishButton.setTexture('FishButton').setInteractive();  // Available
        } else if (fishRole === myConnectionId) {
            this.fishButton.setTexture('ButtonSelected').disableInteractive();  // Selected by me
            localStorage.setItem('role', 'fish');  // Store role in localStorage
        } else {
            this.fishButton.setTexture('FishButtonDisabled').disableInteractive();  // Taken by someone else
        }

        // Hook button logic
        if (hookRole === null) {
            this.hookButton.setTexture('HookButton').setInteractive();  // Available
        } else if (hookRole === myConnectionId) {
            this.hookButton.setTexture('ButtonSelected').disableInteractive();  // Selected by me
            localStorage.setItem('role', 'hook');  // Store role in localStorage
        } else {
            this.hookButton.setTexture('HookButtonDisabled').disableInteractive();  // Taken by someone else
        }

        // Check if player is a spectator
        if (fishRole !== null && hookRole !== null && !spectators.includes(myConnectionId)) {
            localStorage.setItem('role', 'spectator');  // Store role as spectator
        }

        //console.log("FishRole:", fishRole, "HookRole:", hookRole);
        // If both roles are assigned, start the countdown
        //if (fishRole !== null && hookRole !== null) {
        //    console.log("Calling Countdown Method...");
        //    this.connection.invoke('StartGameCountdown');
        //}
    }
}

// Connect to the SignalR hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/gameHub")
    .build();

connection.start()
    .then(() => console.log("SignalR Connected"))
    .catch(err => console.error("SignalR Error: " + err));

// Example: Send game update (you would call this from your game logic)
function sendGameUpdate(gameState) {
    connection.invoke("SendGameUpdate", gameState)
        .catch(err => console.error(err.toString()));
}

// Example: Receive updates from other players
connection.on("ReceiveGameUpdate", function (gameState) {
    console.log("Received Game Update: ", gameState);
    // Here, handle game state updates
});

// Phaser.js Game Logic 
var config = {
    type: Phaser.AUTO,
    width: 800,  // Set base width
    height: 800, // Set base height
    scale: {
        mode: Phaser.Scale.FIT, // Fits to screen size 
        autoCenter: Phaser.Scale.CENTER_HORIZONTALLY,  // Center game canvas horizontally
        parent: 'gameContainer' // Automatically generates the canvas in parent
    },
    physics: {
        default: 'arcade',
        arcade: {
            gravity: { y: 0 },  // No gravity for top-down movement
            debug: false  // Turn off physics debug, set to true for debugging
        }
    },
    scene: [TitleScene, GameScene, HookWinsScene, FishWinsScene]  // Add scenes here

};

var game = new Phaser.Game(config);

