using TMPro;
using UnityEngine;

public class PopupUI : MonoBehaviour
{
  public TMP_Text textField;
  public float moveSpeed = 2f;
  public float lifeTime = 0.5f;
  public void Init(string context, Color color)
  {
    textField.color = color;
    textField.text = context;
  }

  void Start()
  {
    Destroy(gameObject, lifeTime);
  }

  // void Update()
  // {
  //   transform.position += Vector3.up * moveSpeed * Time.deltaTime;
  // }
  // void LateUpdate()
  // {
  //   transform.forward = Camera.main.transform.forward;
  // }
}