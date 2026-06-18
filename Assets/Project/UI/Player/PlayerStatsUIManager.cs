

using UnityEngine;

public class PlayerStatsUIManager : MonoBehaviour
{
  public GameObject statsPanel;
  private PlayerTotalPower playerTotalPower;
  public Transform gridPanel;
  public StatsPanelUI statsPanelUI;
  private bool isOpenPanel = false;

  public void Init(PlayerTotalPower playerPower)
  {
    playerTotalPower = playerPower;
  }
  public void ChangeStatePanel()
  {
    isOpenPanel = !isOpenPanel;
    statsPanel.SetActive(isOpenPanel);
    if (isOpenPanel)
    {
      StatsPanelUI panel = Instantiate(statsPanelUI, gridPanel);
      panel.InitStats(playerTotalPower.playerCombat.playerStats, playerTotalPower.playerWeapon.weaponStats);
      GameStateController.Instance.SetState(GameState.ShowStats);
    }
    else
    {
      GameStateController.Instance.SetState(GameState.Gameplay);
    }
  }
}