

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  private PlayerController input;
  private PlayerMovement movement;


  void Awake()
  {
    input = new PlayerController();
    movement = GetComponent<PlayerMovement>();

  }

  void Update()
  {
    Vector3 inputVector = input.Player.Move.ReadValue<Vector3>();
    if (movement != null) movement.Move(inputVector);
  }

  void OnEnable()
  {
    input.Enable();
  }
  public void OnDisable()
  {
    input.Disable();
  }
}