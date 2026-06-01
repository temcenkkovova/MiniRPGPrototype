using UnityEngine;

public class EnemyAudio : MonoBehaviour
{

  public EnemyAudioConfig enemyAudioConfig;
  private WeaponAudioConfig weaponAudioConfig;

  private EnemyAttackManager attackManager;
  private EnemyHealth enemyHealth;


  void Awake()
  {
    attackManager = GetComponent<EnemyAttackManager>();
    enemyHealth = GetComponent<EnemyHealth>();

  }

  void Start()
  {
    if (attackManager == null || enemyHealth == null) return;
    attackManager.OnAttackStatusChanged += PlayShootAudio;
    enemyHealth.OnDamaged += PlayHitAudio;
    enemyHealth.OnDeath += PlayDeathAudio;

  }

  public void InitWeaponConfig(WeaponAudioConfig weaponConfig)
  {
    weaponAudioConfig = weaponConfig;
  }

  public void PlayShootAudio(bool isShoot)
  {
    if (weaponAudioConfig == null) return;
    if (isShoot)
    {
      var clip = weaponAudioConfig.shootClips[Random.Range(0, weaponAudioConfig.shootClips.Length)];
      float pitch = Random.Range(weaponAudioConfig.pitchMin, weaponAudioConfig.pitchMax);
      AudioService.Instance.PlayAt(transform.position, clip, weaponAudioConfig.volume, pitch);
    }
  }

  public void PlayDeathAudio()
  {
    if (enemyAudioConfig == null) return;
    var clip = enemyAudioConfig.deathClips[Random.Range(0, enemyAudioConfig.deathClips.Length)];
    float pitch = Random.Range(enemyAudioConfig.pitchMin, enemyAudioConfig.pitchMax);
    AudioService.Instance.PlayAt(transform.position, clip, enemyAudioConfig.volume, pitch);
  }

  public void PlayHitAudio(DamageInfo damageInfo)
  {
    if (enemyAudioConfig == null) return;
    var clip = enemyAudioConfig.hitClips[Random.Range(0, enemyAudioConfig.hitClips.Length)];
    float pitch = Random.Range(enemyAudioConfig.pitchMin, enemyAudioConfig.pitchMax);
    AudioService.Instance.PlayAt(transform.position, clip, enemyAudioConfig.volume, pitch);
  }

  void OnDisable()
  {
    if (attackManager == null || enemyHealth == null) return;
    attackManager.OnAttackStatusChanged -= PlayShootAudio;
    enemyHealth.OnDamaged -= PlayHitAudio;
    enemyHealth.OnDeath -= PlayDeathAudio;

  }
}
