using TMPro;
using UnityEngine;

public class ShowNameUI : MonoBehaviour
{
  public TMP_Text nameField;
  public ObjectName objectName;

  void Start()
  {
    if (objectName == null) return;
    nameField.text = objectName.CurrentName;
    objectName.OnNameChanged += ShowName;
  }

  void ShowName(string newName)
  {
    nameField.text = newName;
  }

  void OnDisable()
  {
    if (objectName == null) return;
    objectName.OnNameChanged -= ShowName;
  }
}