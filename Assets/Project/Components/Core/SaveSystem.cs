using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveSystem : MonoBehaviour
{

  // private void OnApplicationQuit()
  // {
  //   // SaveGame();
  // }
  public PlayerLevel playerLevel;
  public InventorySystem inventory;
  public PlayerWeaponController weaponController;
  public List<WeaponItem> allPossibleEquipWeapons;

  [SerializeField] private string path;

  void Awake()
  {
    path = Application.persistentDataPath + "/save.json";
  }
  void Update()
  {

    if (Input.GetKeyDown(KeyCode.F5))
      Save();

    if (Input.GetKeyDown(KeyCode.F9))
      LoadGame();
  }

  public void Save()
  {
    string json = JsonUtility.ToJson(SetSaveData(), true);
    File.WriteAllText(path, json);
  }
  public SaveData SetSaveData()
  {
    SaveData data = new SaveData();
    List<string> inventoryNames = new List<string>();
    foreach (var item in inventory.inventoryItems)
    {
      inventoryNames.Add(item.name);
    }

    data.player = new PlayerData
    {
      Level = playerLevel.CurrentLevel,
      Exp = playerLevel.CurrentExp,
      Coins = GameEconomy.Instance.CurrentCurrency
    };
    data.inventory = new InventoryData
    {
      EquippedWeaponName = weaponController.CurrentWeaponConfig.name,
      InventoryItemsName = inventoryNames,
    };
    data.world = new WorldData
    {
      LastLocation = SceneManager.GetActiveScene().name,
      LastPosition = playerLevel.transform.position,
    };

    return data;
  }

  public void LoadGame()
  {
    if (!File.Exists(path))
    {
      Debug.Log("No save file found");
      return;
    }

    string json = File.ReadAllText(path);
    SaveData data = JsonUtility.FromJson<SaveData>(json);
    inventory.InitSaveItemsName(data.inventory.InventoryItemsName);
    playerLevel.InitSaveLevelData(data.player.Level, data.player.Exp);
    GameEconomy.Instance.InitSavedCurrency(data.player.Coins);
    string equippedWeaponName = data.inventory.EquippedWeaponName;
    WeaponItem foundWeaponConfig = allPossibleEquipWeapons.Find(item => item.weaponConfig.name == equippedWeaponName);
    if (foundWeaponConfig != null)
    {
      weaponController.EquipWeapon(foundWeaponConfig.weaponConfig, foundWeaponConfig);
    }
    else
    {
      Debug.LogWarning($"Item not found: {foundWeaponConfig.name}");
    }
  }
}

