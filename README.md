[Home](https://vanfleet0351.github.io/Kyle-Van-Fleet-Portfolio/)

# MarioRemake
A remake of the classic Mario game for NES.

This was a class project for CSE 3902 at OSU. This project was complete by a 3 person team over the length of a semester.
My team was tasked with recreating the first level of Mario using C# and maintain high quality code and OOP.

[CSE 3902 Course website](https://web.cse.ohio-state.edu/~boggus.2/3902/)


<iframe width="560" height="315" src="https://www.youtube.com/embed/BXWmQbYvASM" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>


### **About the project:**
**Collaborators:** Ali Erdaty (erdaty13@gmail.com), Jalen Soat (soat.3@osu.edu)

**Technology used:** C#, XML, Monogames, Visual Studio, Azur DevOps for version control and agile development tools. 

**Goal:** The goal of this project was to craft high-quality software, understand the process of Agile software development, survey design patterns, become familiar with advanced tools for software development and project management, and experience working in a small sized team.

### **My Contributions:** 

1. **Implementing game controls via keyboard and gamepad.** The game controls were implemented using the command design pattern. This allowed me to encapsulate request as an object and queue requests from the user and handle them approiperiately based on the current state of the game. It also allowed me to log each request which proved usefull when implementing the rewind feature later on.

1. **Implement game objects like block, enemies, items, etc.** The game objects were implemented using the state pattern and have much of the common logic abstracted out leaving only the objects unique AI, animation, and logic in the classes themselves. Each game object is created using the factory pattern and handled by a level manager so they do not affect memory or cpu usage when off screen.

1. **Implement levels and level manager.** The layout of each level is defined using XML, the XML files are parsed by the LevelManger to obtain all the different game objects and their location in the level. The LevelManager uses factories to create each different object and then passes the reference of that object to the level class itself. In the level class each object is drawn, updated, and disposed of when no longer needed.

1. **Implement game states.** The game transitions between levels, menus, pause screen, and so on using the state pattern. Each state class is resposible for loading and unloading the objects associated with that state, as well as updating its repspective level.

1. **Implement screen camera and head up display (HUD).** The screen camera was implemented in a way as to only scroll through the level once the players character has pasted a certain threshold on the screen. This allows the player to move there character around the screen with out being nausiated from the fast moving background images. The HUD is used to keep track of and display points, lives, times, and so on of the player. It is responsible for creating and displaying the floating points on screen when the player kills an enemy or collects coins and power-ups.

1. **Implement Particle effects.** The particle engine is responsible for displaying floating embers around fireballs and colorful swirling stars around Mario when he collects the star power-up.

1. **Implement star power-up and reverse time feature.** These tasks were implemented using the decorator pattern on the player object. The star power-up alters the player object by making them indestructable, flash different colors, and emit a plume of star particles for a short period of time.The revers time feature was acheived by loging the state, position, and controller commands of the player in a stack. When the rewind time button is held down the logged information about the character is popped off the stack allowing the character appear to be moving backwards in time while ignoring the game physics.

1. **General business logic, sound design, and animation.**



### **New features:** 
For the last sprint of this project the team was given the liberty of add our own levels and features that were not present
in the original game.
* <b>Ice flower power-up</b>: Freezes enemies for a short time

<iframe width="560" height="315" src="https://www.youtube.com/embed/Qo-ijEslcdc" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

* <b>Reverse time</b>: Allows the user to reverse time (similar to Braid)

<iframe width="560" height="315" src="https://www.youtube.com/embed/vXtLWfkv814" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

* <b>Veritcal level</b>: To test the players platforming skill

<iframe width="560" height="315" src="https://www.youtube.com/embed/jpzotaU507Q" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
[Home](https://vanfleet0351.github.io/Kyle-Van-Fleet-Portfolio/)
