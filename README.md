# coal-bunker

Project April Design Document

Summary
Project April is a real-time action game developed to play on PC and Mac. The player takes on the role of a warrior who explores randomly generated dungeons. Each dungeon is quick to complete and ends with a boss fight which offers a reward when defeated. Rewards increase the player’s stats or gives them new abilities. As the player grows in power, so do the enemies that they will face. After a set number of dungeons have been traversed, they will encounter a particularly tough boss enemy. Defeating this enemy will end the game with victory for the player. If the player is killed, the game is over and the player must start again with a new game.

Gameplay Loop
The player starts at the entrance to a dungeon, viewed from a top down perspective. Each dungeon is constructed of randomly generated rooms. A single room is visible to the player, but the next or previous rooms are not visible. Each room contains hazards. Hazards always include monsters to defeat, but may also include traps that cause damage. If the player takes too much damage, they die and the game is over.

Dealing with all the challenges in a room causes an exit to appear. Reaching the exit will take the player to the next room in the dungeon. After a certain number of rooms have been beaten, the exit will take the players to a boss room where they fight a tough enemy. If the enemy is defeated, the dungeon is complete, the player’s health is restored and they get a choice of Major Rewards. These rewards are permanent increases to stats or a new ability. The player can only have one ability (other than their basic attack) at any one time, so choosing to take the new ability will replace their old one.

The player will then attempt another dungeon. Each dungeon will be tougher than the last, ensuring the game is still challenging to the player as the player increases in power. After the player has defeated a certain number of dungeons, they enter a final, special dungeon. This is not randomly generated and only contains one room, with a final boss creature. Defeating this creature wins the game for the player.

Player Abilities
The player can move in all directions on a 2D plane, viewed from above at a 3/4 angle. The player starts with one ability, which is an attack with their sword. This attack damages enemies and knocks them back slightly. Multiple attacks can be strung together into a combo. The player may take damage from hazards. Player health is represented by a health indicator in the UI. Taking damage depletes the health indicator. When the health indicator is depleted, the game is over and the player must start again from the first dungeon.

The player has stats that can be increased at the end of each dungeon. These are:
Maximum health
Sword damage
Movement Speed
Attack Speed

The player also has a secondary ability that they can gain after finishing a dungeon. Secondary abilities will be defined in their own section below. Additionally, some rooms will give a minor reward that confer a temporary stat bonus when completed. These minor rewards are defined in their own section.

Rewards
Rewards are split into two categories, Major and Minor. Major rewards are awarded upon completing a dungeon. Minor rewards are awarded when completing a room in the dungeon.

Major Rewards
Major rewards are awarded at the end of each dungeon. They are random, and a player may pick one of three offered. There is a maximum amount each stat can be raised to. After this maximum is reached, these rewards will no longer be offered to the player.
Increase maximum health
Increase sword damage
Increase movement speed
Increase attack speed
Gain a new ability

Minor Rewards
Minor rewards are offered when the player defeats the challenge within a single room of the dungeon. These rewards are all temporary in nature, and are random.
Restore lost health up to the player’s maximum
Grant a boost to sword damage for the next room
Grant a boost to movement speed for the next room
Grant a boost to attack speed for the next room
Gain immunity to the next hit taken

Abilities
New abilities are granted as major rewards. Abilities take the form of items that can be picked up and used. The player can only hold one item at a time. If the player chooses to take an ability as a reward, they will loose the ability they already have (if any). The list of items and the abilities they grant are as follows:
Dodge boots
Gain the ability to perform a dodge roll, moving rapidly in one direction. During the roll, the player cannot be damaged, but can pass through enemies.
Shield
While the shield is held up, the player cannot be damaged from the front. However, the player cannot change the direction they are facing.
Bow
The player gains a ranged attack that deals light damage from a distance. The attack is a projectile that moves slowly. It cannot be spammed and does not knock enemies back.
Bottle
This allows the player to pick up a minor reward and store it for later use. Using the item when the bottle is empty will pick up a minor reward infant of the player. Pressing the button again will use the minor reward. It comes with a random minor reward inside it.

Controls
The player can use a keyboard or a gamepad to control the player. Movement commands are move up, down, left and right, with combinations of these movements producing diagonal movement. If an analogue input is used, such as a stick on a gamepad, then movement in any direction is possible. There are three other buttons used to control the game. An attack button, an item button, and a pause button which brings up the game’s menu.

Hazards
A variety of hazards will confront the player. These hazards come in the form of traps and enemies. They will seek to damage the player. Enemies will not damage each other, even by accident. Enemies can be defeated by damaging them with attacks. Traps can be defeated by avoiding them and defeating all the enemies in a room. A room always contains enemies. A room may or may not contain traps.

Enemies
This section contains a list of all the possible monsters that may appear. This category does not include bosses (see below). This list will be added to as the project progresses.
Enemy State Diagram
The following diagram illustrates the enemy state system that all enemies will use in Project April. If any enemy state differs from the following diagram, the exception will be detailed in the description of the enemy.














Idle: The enemy takes no action.
If the player comes within sight range: Alert
After a random amount of time: select between Idle, Patrol
Patrol: The enemy walks in a random direction for a random amount of time.
If the player comes within sign range: Alert
After a random amount of time: select between Idle, Patrol
Alert: The enemy moves towards the player until they are within attack range.
If the player is in attack range: Attack
If the player moves out of sight range: Idle
Attack: The enemy attacks the player.
After an attack: Alert

Soldier
These enemies will move towards the player and attack with their swords. They are similar to the player in terms of size and attack reach.

Archer
These enemies will move towards the player and attack with their bows. They are similar to the player in terms of size, but their main attack is a projectile weapon that fires a shot that the player could potentially dodge.

Traps
Damage Trap
The damage trap is a stationary object that will damage the player or any enemy that touches it.

Arrow Trap
The arrow trap will fire a projectile similar to the archer’s shot in a single orthogonal direction. It will damage the player or any enemy that is hit by it.

Bosses
[TODO]

Final Boss
[TODO]

Random Dungeon Generation
Each dungeon room will be a single screen consisting of tiles 64 pixels square. Each tile will either be a door, a wall, or a floor. Traps will take up the same space as a wall tile, but are considered hazards, rather than part of the dungeon room itself.

In the algorithm below, the chance a tile will be a wall (in step 4.2) will be determined by a room density value.

Wall Generation Algorithm
Start with a blank room. Every tile is floor.
All out the tiles on the edge of the room are wall tiles.
Two tiles on the edge of the room are door tiles. One is an entrance, the other is an exit.
Start a wall generation loop:
Choose the top left floor tile.
Randomly decide if it will be a wall tile or not.
If it is a wall tile, evaluate whether or not placing a wall tile here will prevent access from the entrance to the exit.
Choose the next tile below the current tile. If the next tile is a wall, we have reached the bottom. Choose the next floor tile at the top of the next column.
Repeat from 2.
Once all floor tiles have been evaluated, Check each remaining floor tile to see if it can be reached from the entrance. If not, make it a wall.
Random dungeon complete. Spawn enemies.

Hazard Generation Algorithm
Choose the amount of traps to appear based on the room difficulty and the room density.
Start trap generation loop:
Randomly choose a floor tile.
Check to see if placing a trap there will block a path from the entrance to the exit. If it does, cancel the trap placement.
Place the trap.
Repeat from 1.
Choose the amount of enemies to appear based on the room difficulty.
Start enemy generation loop:
Randomly choose a free floor tile.
Ensure that if an enemy is placed in this tile, it can be reached from the entrance door. If it cannot, choose a different tile.
Randomly choose an enemy type.
Place the enemy.
Repeat from 1.

Art Assets
This section details the creation of art assets. Art assets are considered to be graphics for dungeon scenery, UI and object sprites, any sound assets such as sound effects or music.

Graphics
[TODO]

Sound
[TODO]

Development Milestones
The game will be developed in a series of stages, referred to as milestones. These are roughly defined as follows:

Basic Gameplay Prototype
This will produce the basic gameplay of a room in a dungeon. No element of it will be randomly generated and the main purpose of this stage is to pin down the basic combat mechanics. The prototype will feature the player and three soldier enemies. The placement of enemies will be random within the room. The enemies will display basic AI and move towards the player in an attempt to attack. The player will be able to move and attack the enemies. Once all the enemies are defeated, or the player runs out of health, the game will end and the player will be given the opportunity to quit or restart.

Random dungeon room
This will behave similarly to the basic gameplay prototype, but the room will be randomly generated with enemies and traps. Each enemy will either be a soldier or an archer. Traps are not guaranteed to appear every time. Once to room is cleared, a minor reward will be dropped and the player will be able to exit the room. Once this happens, the player will be given the opportunity to quit the game or restart.

Dungeon
This milestone will be a full playable dungeon with multiple rooms connected by doors. The rooms will have random types of encounters in them, either a variety of enemies, or traps, or both. Once all rooms in the dungeon have been cleared, the final door will end the game and allow the player to quit or restart. No dungeon bosses or major rewards will feature here, but minor rewards upon completing dungeon rooms will be awarded.

Boss Room
This is a complete boss encounter. It will take the form of a room with a single boss enemy in it. Once the boss enemy is destroyed, an exit to the dungeon will appear. Reaching the exit will cause the prototype to end and the player will be able to quit or restart.

Full Dungeon
This is a merging of milestones 3 and 4. The player should be able to play through a multi-room dungeon with minor rewards, then access a boss fight. Upon completing the boss fight, the game will end and can be restarted with a different random dungeon.

Full Dungeon with Progression
Major rewards will be added to the end of each dungeon from milestone 6. Each time a player defeats a boss, they will be offered the choice of three rewards. The only available rewards will be random stat boosts. Obtaining a major reward will result in a permanent stat boost (up to a maximum) and will carry over into the next dungeon. A status screen must be displayed between dungeons, showing the player’s current stats. The player can keep playing until they defeat 5 dungeons. The game will then end.

Abilities
New abilities will be added to the major rewards. There must be at least two different types. Each choice of major rewards will now be two different stat boosts and one ability. The abilities must work in both dungeons and boss rooms. If a player opts to take a new ability, the old one will be forfeit.

Final Boss Encounter.
A final boss will be added as a special, non random dungeon room which the player accesses after they have defeated 5 regular dungeons. This boss dungeon will contain a corridor leading to a single room, containing a unique boss not fought at the end of any other dungeon. Defeating this boss will end the game and display a win screen to the player.


Technical Specification
The game will be developed in Game Maker Studio 2 on a Mac system. Initially it will be developed with no effort made towards compatibility with other systems or screen resolutions, until the final milestone has been reached. Once this has occurred, optimisation and system porting will commence. Game Maker Studio is already built with compatibility across multiple systems in mind so this will reduce the amount of work required to have the game run on PC.

Narrative Design

She had been awake before on nights like this. The wind slid through the forest. It came from the west, bringing tales of empty cities full of secrets, written on knives pushed through the cracks at the edge of the shuttered window. She opened the latch, letting the shutters snap back and allowing their stories to wash over her and in to the dingy room. She curled her fingers on the rough wooden sil and leaned out into the dark. Eyes closed, head tilted high, she listened for news from beyond the mountains, beyond the coast, away to her home, the floating city of Shil. They told her of a stranger camped on a faraway hill, embers of his dying fire throwing deep shadows into the recesses of a cragged face. Old, deep, watery viscous eyes gleamed as they watched the embers die. They told her of a lone stag atop a ruined hill. Powerful legs strode through cracked black rocks, eyes flashed in the starlight. They told her of a furtive hare with a lame leg, head high listening to the night just as she did. Daring the night to ask her the question “can you run?”. They told her all of this, but they did not tell her of the floating city of Shil. She had been awake before on nights like this.

It was midnight and moonless. She leaned further out of the window. Tonight she would leave for the last time. There had been no news for a year, and she had to see for herself. She would leave tonight. She took her mother’s sword and her father’s shield. She took her uncles boots and her grandmother’s book, and her grandfather’s cape. She took her lover’s gloves, still warm from their earlier outing. Finally, she took quill and ink, and wrote a letter of reassurance and well wishes. She leaned further out of the window, pushed one leg on the edge of the sil, and took her leave.