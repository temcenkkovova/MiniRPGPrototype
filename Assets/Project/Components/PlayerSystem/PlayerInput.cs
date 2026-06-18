

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
  private PlayerController input;
  private PlayerMovement movement;
  private PlayerStatsUIManager statsUIManager;

  private PlayerAttackManager playerAttackManager;
  private PlayerInteractionController interactionController;
  public NpcShop npcShop;
  public InventoryManagerUI inventoryManager;


  void Awake()
  {
    input = new PlayerController();
    movement = GetComponent<PlayerMovement>();
    playerAttackManager = GetComponent<PlayerAttackManager>();
    interactionController = GetComponent<PlayerInteractionController>();
    statsUIManager = GetComponent<PlayerStatsUIManager>();
  }

  void Update()
  {
    if (!GameStateController.Instance.IsGameplayState()) return;
    Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();
    if (movement != null) movement.Move(inputVector);

  }

  void OnEnable()
  {
    input.Enable();
    input.Player.Sprint.started += OnSprintStarted;
    input.Player.Sprint.canceled += OnSprintCanceled;
    input.Player.Attack.performed += OnAttackStarted;
    input.Player.Interact.performed += OnInteractStarted;
    input.Player.Shop.performed += OnShopStarted;
    input.Player.Inventory.performed += OnInventoryStarted;
    input.Player.Stats.performed += OnStatsStarted;
  }
  public void OnDisable()
  {
    input.Disable();
    input.Player.Sprint.started -= OnSprintStarted;
    input.Player.Sprint.canceled -= OnSprintCanceled;
    input.Player.Attack.performed -= OnAttackStarted;
    input.Player.Interact.performed -= OnInteractStarted;
    input.Player.Shop.performed -= OnShopStarted;
    input.Player.Inventory.performed -= OnInventoryStarted;
    input.Player.Stats.performed -= OnStatsStarted;
  }

  public void OnStatsStarted(InputAction.CallbackContext context)
  {
    statsUIManager.ChangeStatePanel();
  }
  public void OnInventoryStarted(InputAction.CallbackContext context)
  {
    if (inventoryManager.IsOpen)
    {
      inventoryManager.CloseInventory();
    }
    else
    {
      if (!GameStateController.Instance.IsGameplayState()) return;
      inventoryManager.OpenInventory();
    }
  }
  public void OnShopStarted(InputAction.CallbackContext context)
  {

    if (npcShop.ShopStatus())
    {
      npcShop.HandleCloseShop();
    }
    else
    {
      if (!GameStateController.Instance.IsGameplayState()) return;
      npcShop.HandleOpenShop();
    }

  }
  public void OnSprintStarted(InputAction.CallbackContext context)
  {
    if (!GameStateController.Instance.IsGameplayState()) return;
    movement.ChangeSprintState(true);
  }
  public void OnSprintCanceled(InputAction.CallbackContext context)
  {

    movement.ChangeSprintState(false);
  }
  public void OnAttackStarted(InputAction.CallbackContext context)
  {
    if (!GameStateController.Instance.IsGameplayState()) return;
    playerAttackManager.ManageAttack();
  }
  public void OnInteractStarted(InputAction.CallbackContext context)
  {

    interactionController.HandleInteract();
  }
}