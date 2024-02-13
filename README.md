

# Project Thomas
Project Thomas is a gameplay prototype clone of the game 'Thomas was Alone' by Bithell Games. It was developed by Manuel Danze as a project in Mobile-Game-Development lecture at the Stuttgart Media University in WS23/24. Unity 2022.3.11f1 was used as the game engine.


## Installation
You can either build a version for the platform of your choice by yourself via Unity Editor, or get a Android.apk under the following link:
https://cloud.mi.hdm-stuttgart.de/s/dbWBe883fjrYEtD

## Controls
- PC/MAC:
```
A,D     move
SPACE   jump
Q       switch character
LMB     navigate menus
```
- Mobile:
```
virtual Left-Stick  move
virtual A-Button    jump
virtual B-Button    switch character
virtual x-Button    exit to menu, close game
```

## Save System
- when you return to menu or close the game, the last played level is saved
- the last saved level will be loaded when you start the game via Menu_Screen Start button



 ## BUGs
 - When playing the Android.apk, after reaching all goals the loading of the next level will not trigger. (works fine in the Unity Editor)
 The save system works in the .apk (was tested manually by manipulating the Savefile.save file)
 
- When playing the Android.apk, it can happen that the red character gets more momentum than intended when jumping and is catapulted to the ceiling, this problem only occurs in the .apk and only for the red character.
(works fine in the Unity Editor)

 - It can happen that a character can no longer jump because its Groundchecker was triggered by a collision with another character or walls (probably if the collision was not calculated correctly by the engine, glitch). A reset by death or restart helps here.

 - It can happen that the overlap of character and its target is not queried correctly although all characters are in their specific target, this means that the next level is not triggered. Switching through all the characters again and moving them briefly will help here.