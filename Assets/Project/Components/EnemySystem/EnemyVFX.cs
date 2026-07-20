using UnityEngine;

public class EnemyVFX : MonoBehaviour
{


  private EnemyHealth enemyHealth;
  private BloodEffectSpawner bloodEffectSpawner;

  void Awake()
  {

    enemyHealth = GetComponent<EnemyHealth>();
  }

  void Start()
  {
    if (enemyHealth == null) return;

    enemyHealth.OnDamaged += SpawnBloodEffect;
  }

  public void InitBloodEffectSpawner(BloodEffectSpawner bloodEffectSpawner)
  {
    this.bloodEffectSpawner = bloodEffectSpawner;
  }

  private void SpawnBloodEffect(DamageInfo damageInfo)
  {
    bloodEffectSpawner.Spawn(damageInfo.hitPoint);
  }
  void OnDisable()
  {
    if (enemyHealth == null) return;
    enemyHealth.OnDamaged -= SpawnBloodEffect;
  }
}