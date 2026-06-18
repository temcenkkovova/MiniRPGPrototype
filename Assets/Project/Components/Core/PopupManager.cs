
using UnityEngine;

public class PopupManager : MonoBehaviour
{

  public Popup prefab;


  public void Show(string context, Transform trParent, Color color)
  {
    Vector3 offset = new Vector3(
    Random.Range(-0.5f, 0.5f),
    Random.Range(0.5f, 1.5f),
    0f
);

    Popup popup = Instantiate(prefab, trParent.localPosition + offset, Quaternion.identity);

    popup.Init(context, color);

  }


}