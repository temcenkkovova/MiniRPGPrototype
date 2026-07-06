using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
  public ParticleSystem levelUpVFX;
  private PlayerLevel playerLevel;

  void Awake()
  {
    playerLevel = GetComponent<PlayerLevel>();
  }

  void Start()
  {
    if (playerLevel == null) return;
    playerLevel.OnLevelUpdate += LevelUp;
  }


  private void LevelUp(int level)
  {
    levelUpVFX.Play();
  }

  void OnDisable()
  {
    if (playerLevel == null) return;
    playerLevel.OnLevelUpdate -= LevelUp;
  }
}