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
        });

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
        this.fish.setCollideWorldBounds(true);
        this.hook.setCollideWorldBounds(true);

        // Play the animations
        this.fish.play('swim');
        this.hook.play('hookMove');

        // Create the Trash group
        this.trashGroup = this.physics.add.group();

        // Setup input handling for both Fish and Hook 
        this.input.on('pointermove', this.setTargetPosition, this);

        // Enable collision detection between Hook, Fish, and Trash
        this.physics.add.overlap(this.hook, this.fish, this.hookWins, null, this);
        this.physics.add.overlap(this.hook, this.trashGroup, this.fishWins, null, this);
    }

    // Store the target position on click
    setTargetPosition(pointer) {
        if (this.playerRole === 'fish') {
            this.fishTarget = { x: pointer.x, y: pointer.y };
        } else if (this.playerRole === 'hook') {
            this.hookTarget = { x: pointer.x, y: pointer.y };
        }
    }

    // Update method runs every frame
    update() {
        if (this.playerRole === 'fish') {
            this.moveToTarget(this.fish, this.fishTarget, 200);
            this.broadcastPosition('fish', this.fish);  // Continuously send the Fish position
        } else if (this.playerRole === 'hook') {
            this.moveToTarget(this.hook, this.hookTarget, 170);
            this.broadcastPosition('hook', this.hook);  // Continuously send the Hook position
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

    // Spawn trash for spectators
    spawnTrash(pointer) {
        let trash = this.trashGroup.create(0, pointer.y, 'Trash').setScale(1);
        trash.setVelocityX(150);  // Move trash to the right at a fixed speed
    }

    // Collision detection: Hook catches Fish
    hookWins() {
        this.scene.start('TitleScene');  // Transition to HookVictoryScene
    }

    // Collision detection: Hook hits Trash
    fishWins() {
        this.scene.start('TitleScene');  // Transition to FishVictoryScene
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
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl("/gameHub")
            .build();

        this.connection.start().then(() => {
            console.log("Connected to SignalR");

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

    updateRoleButtons(fishRole, hookRole) {
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

        // If both roles are assigned, start the countdown
        if (fishRole !== null && hookRole !== null) {
            this.connection.invoke('StartGameCountdown');
        }
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
    scene: [TitleScene, GameScene]  // Add scenes here

};

var game = new Phaser.Game(config);

