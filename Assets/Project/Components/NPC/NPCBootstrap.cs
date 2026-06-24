using UnityEngine;
public enum NPCRole
{
  Shop,
  Quest,
}

public class NPCBootstrap : MonoBehaviour
{
  public NPCRole role;

  public void Interact()
  {
    switch (role)
    {
      case NPCRole.Shop:
        OpenShop();
        return;

      case NPCRole.Quest:
        OpenQuestDialog();
        return;
    }
  }

  public void OpenShop()
  {
    NpcShop shop = GetComponent<NpcShop>();
    shop.HandleOpenShop();
  }

  public void OpenQuestDialog()
  {
    Quest quest = GetComponent<Quest>();
    quest.OpenDialog();
  }

}