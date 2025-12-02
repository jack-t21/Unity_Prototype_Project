## Unity Prototype Project
###### By: Jack Travers

### Description
This project is a prototype for a simple character movement system. This includes first-person and third-person camera controls, movement mechanics, input handling scripts, and animation handling. It is intended to provide a learning experience that explored Unity's Systems, C# scripting, and gameplay design.

### Features

Here are some of the features of this project:
- Player movement and input handling scripts. This includes:
    - Walking, strafing, reversing, and jumping, with running states for each
    - Collision detection, incline handling, and gravity
    - Serialized fields for easy editing of values like speed, jump force, sprint multiplier, and more
- First-person and third-person camera views with tuned camera behavior
    - Currently working to make them togglable between each other
- Modular script structure for further expansion
- Animation handling script with editable animation acceleration and deceleration
- Animator controller state machine using blend trees for smoother animation transitions

### Project Structure

Below is the file structure of this project:

- `Assets/` – All scripts, prefabs, models, and scenes
    - **`Assets/Scripts/ControlPlayer`** - Contains the main scripts and prefabs of the project
    - `Assets/Scenes` - Contains the scene of the project
        - `SampleScene.Unity`
- `Packages/` – Unity package dependencies
- `ProjectSettings/` – Project configuration files
- `.gitignore` – Ensures `Library`, `Temp`, `Logs`, and other generated files are excluded from Git

### Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/jack-t21/Unity_Prototype_Project.git
   ```  
2. Open the project in **Unity Hub**.
3. Open the main scene located in `Assets/Scenes`.
4. Play the scene in the editor to test the player controller:
   - Switch between first-person and third-person camera views.
   - Test movement, input handling, and animations.
5. Modify or extend gameplay mechanics by editing scripts or animation handlers in **`Assets/Scripts`**
6. All changes to assets and scripts can be tracked via Git; temporary Unity files in `Library/`, `Logs/`, and `Temp/` are ignored.