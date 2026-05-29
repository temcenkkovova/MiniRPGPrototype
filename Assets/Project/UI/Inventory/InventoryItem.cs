using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
  public Image iconField;
  private ItemData itemData;


  public void Init(ItemData item)
  {
    itemData = item;
    iconField.sprite = item.icon;

  }

  public void HandleBuyClick()
  {

  }

}