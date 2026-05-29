using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
  public Image iconField;
  public TMP_Text titleField;
  public TMP_Text descriptionField;
  public TMP_Text priceField;
  public Button priceBtn;
  private ItemData itemData;

  private ShopSystem shopSystem;
  public void Init(ItemData item, ShopSystem shop)
  {
    itemData = item;
    iconField.sprite = item.icon;
    titleField.text = item.title;
    priceField.text = item.price.ToString();
    shopSystem = shop;
  }

  public void HandleBuyClick()
  {
    shopSystem.BuyItem(itemData);
  }

}