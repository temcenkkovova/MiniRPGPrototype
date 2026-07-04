using System;
using UnityEngine;

public class ObjectName : MonoBehaviour
{
  private string currentName;
  public string CurrentName => currentName;
  public event Action<string> OnNameChanged;





  public void InitName(string newName)
  {
    if (currentName == newName) return;
    currentName = newName;
    OnNameChanged?.Invoke(currentName);
  }
}