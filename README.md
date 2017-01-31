# 3D-Camera

3D camera movement for people to use for their game (main player)

There are 3 script that you can use for the camerea and 1 script for the player. Each script have different point of view for how the player can see the mian character in the game.

CameraMovement A dungeon crawler camera, where the camera follow the player like a delayed magnet. Basically, when you move the player, the camera will follow the player with a certain offset, but after a brief momment of not moving the player, the camera will move closer the player. Games for example -> Diablo
 
~~CameraMovementSecobd This is a basic TPS(third person camera). It will follow the player when the player move with a certain distance from the player. And the camera will turn as the player turn around. This camera is great for games that concentrate on exploring areas, rather than shooting. Game for that used this type of camera is Mario Galaxy~~

CameraThird This camera is fimiliar with the second camera, but it use the mouse to control the direction the player is looking, more like an fps game. This camera is more suited for shooting TPS game, since it follows the direction of what the player is facing. I also added a zoom function for the player to play around with, since I made this camera for a TPS game. Game for example -> any TPS game that uses mouse as your pointer, similar like Uncharted games

OtherCamera Script is a mcuh better version of the CameraMovementSecobd, which has 2 types camera movement. 1st type is a camera where it will follow the player, after the users press a certain button. It will move faster the farther the character move away from the current position of the camera. The camera will follow even the player move, until the camera reach the certain points. 2nd type makes the camera to follow the player as soon the player lift the moving button or after a certain second, according to how long the users want to sets the timer on. 

OtherNewCamera is just a top view camera which follow the character, which had a little bit lag. It's just a simple camera that can be used in a RTS games or just top down stratey games. It aslo can be used in a top down shooting or a top down puzzle. But for this part, it can be only implemented on a target. 

# How to Use this Script

- Create an object and set the player PlayerMovement script, so you can move the object around
- Next, attach any of the scripts for the camera on the main camera. )You don't need to make the camera the child of the player)
- Use 'WASD' key to move around and 'QE' to turn around
- Use 'L' and 'O' to change the damping/Rotation Speed of the camera -> Damping for CameraMovement , Rotation Speed for CameraThird. Damping is used to handle on the angle of the camera and how fast the camera will go back to the player. 
- Use 'Space' and 'V' to change the offset for the CameraMovement -> for this button it only was used in that script. Offset is used to for the zoom in or out for this camera
- 'Space' is also used for the key for making the camera move on the OtherCamera
- Use mouse scroll, to zoom in and zoom out -> this function is applied for the CameraThird and OtherNewCamera.
- There are bunch of variables that users can use to set the angle, postion and speed of the camera. There are certain variables, like the offset, etc but most of them are adjustable on the game you're using. 
