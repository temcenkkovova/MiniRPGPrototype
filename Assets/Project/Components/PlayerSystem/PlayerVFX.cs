using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
  public ParticleSystem levelUpVFX;
  private PlayerLevel playerLevel;
  private PlayerHealth playerHealth;
  public BloodEffectSpawner bloodEffectSpawner;

  void Awake()
  {
    playerLevel = GetComponent<PlayerLevel>();
    playerHealth = GetComponent<PlayerHealth>();
  }

  void Start()
  {
    if (playerLevel == null || playerHealth == null) return;
    playerLevel.OnLevelUpdate += LevelUp;
    playerHealth.OnDamaged += SpawnBloodEffect;
  }


  private void LevelUp(int level)
  {
    levelUpVFX.Play();
  }
  private void SpawnBloodEffect(DamageInfo damageInfo)
  {
    bloodEffectSpawner.Spawn(damageInfo.hitPoint);
  }
  void OnDisable()
  {
    if (playerLevel == null || playerHealth == null) return;
    playerLevel.OnLevelUpdate -= LevelUp;
    playerHealth.OnDamaged -= SpawnBloodEffect;
  }
}