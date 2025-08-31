# Pong
This is a basic recreation of the classic Pong game, build with Unity and C#.
## Quick Start
* Download the archive associated with your operating system and extract it.
* Execute the start file associated with your operating system
* Your paddle is on the left
  * Use the arrow keys (or 'w'/'s') to move the paddle up and down.
* Press the space bar to pause the game.
  * The 'Quit game' button will exit the game
  * Pressing 'Escape' will exit the game
  * Alternatively, use your Operating system's method for closing the window
* There is no score, so play until you are bored.

## Building from Source
These following instructions assume you are on a Linux system.
1. Open the terminal and run the following commands:
```
$ mkdir -p ~/Unity/projects
$ git clone https://github.com/JMGillum/cs-3383-pong.git ~/Unity/projects/pong
```
  * This clones the code repository in the default location. Feel free to clone to another location
1. Install Unity hub, following the instructions from [https://unity.com/download]. Then launch it.
1. Navigate to the 'Installs' tab on the left
1. Install Unity 6.2 (6000.2.1f1)
1. On the left, navigate to 'Projects' tab.
1. On the right, click 'Add' > 'Add project from disk'.
1. Select the folder `~/Unity/projects/pong`.
1. Click on 'pong' to launch the unity editor.
1. Once loaded, drag the desired scene from the assets panel to the hierarchy panel to start editing it.
1. Click 'File' > 'Build profiles' to enter the build menu, where you can build the game for the desired operating system.

### Commits
Only files from the following folders should be commited:
```
./Assets/
./Packages/
./ProjectSettings/
```
DO NOT COMMIT ANYTHING FROM:
```
./Library/
./Logs/
./Temp/
```
Unity will automatically create all of the necessary files from these folders when loading the project in the editor.

### Releases
Releases follow a <Major_Edit>.<Minor_Edit> semantic versioning system.\
Releases on github should be accompanied with an archive of the builds for Windows 64-bit and Linux x86 64-bit.
