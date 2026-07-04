# UsefulScriptsForUnityGameDev
Useful scripts for game development in Unity

## 3D

### FirstPersonCamera
Must be assigned to the Camera in a default transform's parent structure (pos 0,0,0 ; rot 0,0,0 ; sca 1,1,1) as the Camera's GameObject rotate and its parent move.

### GameManager
This serves as the foundation for the game's global functions and variables, making them accessible to all GameObjects instantiated after the initial load. This component must be set on a single GameObject called "GameManager" above all GameObjects in the scene-hierarchy who need them.

### Note
Usefull to add more secret lore to the game. Requires a WorldTrigger component.

### Player
3D basic first person player controller base on CharacterController. Move, jump and ground-stabble fonctionnality.

### QuestManager
WorldTrigger based quests : active triggers from first to last to complete the quest. Easily modifiable to get separated and multiple quest simultaneously (with an "actual-followed" quest selection).

### WorldTrigger
Invoke its event when triggered. Multi-trigger must be added to its functionnalities soon. Check "re_use" if you want it to be usable multiple times. Or lock it if it's not the right time to use it from Start. Require a GameManager active in the scene.

### Billboard
Stabilizes the rotation of flat objects (2D images) in the scene so that they are oriented perpendicular to the camera.


## 2D

### CameraController
Smoothly follow the target. Offset's z axis must be set to -10.
