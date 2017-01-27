# 3D-Camera1

3D camera movement for people to use for their game (main player)

There are 3 script that you can use for the camerea and 1 script for the player. Each script have different point of view for how the player can see the mian character in the game.

CameraMovement A dungeon crawler camera, where the camera follow the player like a delayed magnet. Basically, when you move the player, the camera will follow the player with a certain offset, but after a brief momment of not moving the player, the camera will move closer the player. Games for example -> Diablo
 
CameraMovementSecobd This is a basic TPS(third person camera). It will follow the player when the player move with a certain distance from the player. And the camera will turn as the player turn around. This camera is great for games that concentrate on exploring areas, rather than shooting. Game for that used this type of camera is Mario Galaxy

CameraThird This camera is fimiliar with the second camera, but it use the mouse to control the direction the player is looking, more like an fps game. This camera is more suited for shooting TPS game, since it follows the direction of what the player is facing. Game for example -> any TPS game that uses mouse as your pointer, similar like Uncharted games

# How to Use this Script

- Create an object and set the player PlayerMovement script, so you can move the object around
- Next, attach any of the scripts for the camera on the main camera. )You don't need to make the camera the child of the player)
- Use 'WASD' key to move around and 'QE' to turn around
- Use 'L' and 'O' to change the damping of the camera 
- Use 'Space' and 'V' to change the offset
