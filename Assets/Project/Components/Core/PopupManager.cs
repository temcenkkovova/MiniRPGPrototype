
using UnityEngine;

public class PopupManager : MonoBehaviour
{

  public Popup prefab;
  public PopupUI prefabUI;

  public void Show(string context, Transform trParent, Color color)
  {
    Vector3 offset = new Vector3(
    Random.Range(-0.5f, 0.5f),
    Random.Range(0.5f, 1.5f),
    1f
);

    Popup popup = Instantiate(prefab, trParent.localPosition + offset, Quaternion.identity);

    popup.Init(context, color);

  }

  public void ShowUI(string context, Transform trParent, Color color)
  {
    Vector3 offset = new Vector3(
   Random.Range(-0.5f, 0.5f),
   Random.Range(0.5f, 1.5f),
   1f);

    PopupUI popup = Instantiate(prefabUI, trParent);

    popup.Init(context, color);
  }


}