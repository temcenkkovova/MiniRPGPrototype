# Mini RPG Prototype

**A third-person action RPG prototype built with Unity, combining melee combat, enemy AI, quests and character progression.**

Explore a forest environment, fight enemies, complete NPC quests and earn experience and coins. Buy weapons, manage your inventory and equip new gear to improve your combat capabilities. Save your character progression, equipment and location to continue later.

## Core Mechanics & Code

| System | Implementation | Key code |
| --- | --- | --- |
| Player movement & camera | Camera-relative movement and sprinting using `CharacterController`, with a custom orbiting third-person camera. | [PlayerMovement](Assets/Project/Components/PlayerSystem/PlayerMovement.cs), [ThirdPersonCamera](Assets/Project/Components/CameraRig/ThirdPersonCamera.cs) |
| Melee combat | Weapon hitboxes apply damage calculated from character and weapon stats. | [MeleeAttack](Assets/Project/Components/Combat/MeleeAttack.cs), [SwordHitBox](Assets/Project/Components/Combat/SwordHitBox.cs) |
| Enemy AI | A finite state machine separates idle, patrol, chase, attack and death behavior. | [EnemyFSMController](Assets/Project/Components/EnemySystem/FSM/EnemyFSMController.cs), [EnemyStates](Assets/Project/Components/EnemySystem/FSM/EnemyStates) |
| Quests & rewards | Accept NPC quests, track kills of specified enemies, turn in completed objectives and receive experience and coins. | [QuestSystem](Assets/Project/Quest/QuestSystem.cs), [QuestManager](Assets/Project/Quest/QuestManager.cs) |
| Character progression | Gain experience and level up, with increasing experience requirements and UI updates driven by events. | [PlayerLevel](Assets/Project/Components/PlayerSystem/PlayerLevel.cs), [PlayerRewardSystem](Assets/Project/Components/PlayerSystem/PlayerRewardSystem.cs) |
| Inventory & trading | Purchase, equip and sell weapons, keeping inventory and shop availability synchronized. | [InventorySystem](Assets/Project/Components/Inventory/InventorySystem.cs), [ShopSystem](Assets/Project/Components/Shop/ShopSystem.cs), [TradeSystem](Assets/Project/Components/Shop/TradeSystem.cs) |
| Save & load | Store level, experience, coins, inventory, equipped weapon, scene and position in a local JSON file. | [SaveSystem](Assets/Project/Components/Core/SaveSystem.cs) |
| Respawn | Return the player to a designated respawn point and restore health. | [PlayerRespawn](Assets/Project/Components/PlayerSystem/PlayerRespawn.cs) |

## Technical Highlights

- **Component-based design:** separate responsibilities for movement, combat, stats, equipment, rewards and UI.
- **Finite state machine:** enemy states implement a shared `IEnemyState` interface with explicit entry, update and exit behavior.
- **ScriptableObject configurations:** define players, enemies, weapons, quests, shop items and audio outside gameplay logic.
- **C# events:** connect enemy kills, quest completion, progression, inventory changes and interface updates.
- **Shared combat interfaces:** use `ICombatStats` and `IDamageable` to separate combat logic from specific character implementations.
- **JSON persistence:** serialize save data with `JsonUtility` and restore it after asynchronous scene loading.
- **Audio pooling:** reuse `AudioSource` instances for positional sound effects through [AudioService](Assets/Project/Components/Core/AudioService.cs).

**Stack:** Unity 2021.3 LTS · C# · 3D Physics · Input System · TextMesh Pro

## Run

Clone or download the repository, open it in **Unity 2021.3.45f2**, then open `Assets/Project/Scenes/DarkForest.unity` and press **Play**.

**Controls:**
- `W/A/S/D` — move.
- `Left Shift` — sprint.
- `Left Mouse Button` — attack.
- Hold `Right Mouse Button` and move the mouse — rotate the camera.
- `E` — interact.
- `N` — toggle the shop.
- `I` — toggle inventory.
- `P` — toggle character stats.
- `F5` — save.
- `F9` — load.

**Save scope:** Saves character progression, inventory, equipment and location. Quest progress is not included in the current save data.
