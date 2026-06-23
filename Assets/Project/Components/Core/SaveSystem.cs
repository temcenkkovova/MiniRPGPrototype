using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveSystem : MonoBehaviour
{

  // private void OnApplicationQuit()
  // {
  //   // Save();
  // }
  private PlayerLevel playerLevel;
  private InventorySystem inventory;
  private PlayerWeaponController weaponController;
  public List<WeaponItem> allPossibleEquipWeapons;
  private ShopSystem shopSystem;

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
    playerLevel = FindObjectOfType<PlayerLevel>();
    inventory = FindObjectOfType<InventorySystem>();
    weaponController = FindObjectOfType<PlayerWeaponController>();
    shopSystem = FindObjectOfType<ShopSystem>();
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
    StartCoroutine(LoadSceneAndApplyData(data));
  }
  private System.Collections.IEnumerator LoadSceneAndApplyData(SaveData data)
  {
    //Need to use Coroutine because I have to set new data after scene  load;
    AsyncOperation operation = SceneManager.LoadSceneAsync(data.world.LastLocation);

    while (!operation.isDone)
      yield return null;

    /*It`s important to find components by using FindObjectOfType because of SaveSystem does not destroy during scene is changing*/
    playerLevel = FindObjectOfType<PlayerLevel>();
    inventory = FindObjectOfType<InventorySystem>();
    weaponController = FindObjectOfType<PlayerWeaponController>();
    shopSystem = FindObjectOfType<ShopSystem>();
    inventory.InitSaveItemsName(data.inventory.InventoryItemsName);
    playerLevel.InitSaveLevelData(data.player.Level, data.player.Exp);
    GameEconomy.Instance.InitSavedCurrency(data.player.Coins);
    shopSystem.RefreshShop();
    WeaponItem foundWeapon = allPossibleEquipWeapons.Find(
    item => item.weaponConfig.name == data.inventory.EquippedWeaponName
);

    if (foundWeapon != null)
    {
      weaponController.EquipWeapon(foundWeapon.weaponConfig, foundWeapon);
    }
    else
    {
      Debug.LogWarning($"Weapon not found: {data.inventory.EquippedWeaponName}");
    }
    playerLevel.GetComponent<PlayerRespawn>().HandleLoadedPosition(data.world.LastPosition);

  }
}

