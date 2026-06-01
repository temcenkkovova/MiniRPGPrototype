using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
  public PlayerAudioConfig playerAudioConfig;
  private WeaponAudioConfig weaponAudioConfig;

  private PlayerAttackManager attackManager;
  private PlayerHealth playerHealth;
  private PlayerMovement playerMovement;

  void Awake()
  {
    attackManager = GetComponent<PlayerAttackManager>();
    playerHealth = GetComponent<PlayerHealth>();
    playerMovement = GetComponent<PlayerMovement>();

  }

  void Start()
  {
    if (attackManager == null || playerHealth == null || playerMovement == null) return;
    attackManager.OnAttackStatusChanged += PlayShootAudio;
    playerHealth.OnDamaged += PlayHitAudio;
    playerHealth.OnDeath += PlayDeathAudio;
    playerMovement.OnSprintChanged += PlaySprintAudio;
  }

  public void InitWeaponConfig(WeaponAudioConfig weaponConfig)
  {
    weaponAudioConfig = weaponConfig;
  }
  public void PlaySprintAudio(bool isSprint)
  {
    if (isSprint)
    {
      var clip = playerAudioConfig.sprintClips[Random.Range(0, playerAudioConfig.sprintClips.Length)];
      float pitch = Random.Range(playerAudioConfig.pitchMin, playerAudioConfig.pitchMax);
      AudioService.Instance.PlayAt(transform.position, clip, playerAudioConfig.volume, pitch);
    }
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
    if (playerAudioConfig == null) return;
    var clip = playerAudioConfig.deathClips[Random.Range(0, playerAudioConfig.deathClips.Length)];
    float pitch = Random.Range(playerAudioConfig.pitchMin, playerAudioConfig.pitchMax);
    AudioService.Instance.PlayAt(transform.position, clip, playerAudioConfig.volume, pitch);
  }

  public void PlayHitAudio(DamageInfo damageInfo)
  {
    if (playerAudioConfig == null) return;
    var clip = playerAudioConfig.hitClips[Random.Range(0, playerAudioConfig.hitClips.Length)];
    float pitch = Random.Range(playerAudioConfig.pitchMin, playerAudioConfig.pitchMax);
    AudioService.Instance.PlayAt(transform.position, clip, playerAudioConfig.volume, pitch);
  }

  void OnDisable()
  {
    if (attackManager == null || playerHealth == null || playerMovement == null) return;
    attackManager.OnAttackStatusChanged -= PlayShootAudio;
    playerHealth.OnDamaged -= PlayHitAudio;
    playerHealth.OnDeath -= PlayDeathAudio;
    playerMovement.OnSprintChanged -= PlaySprintAudio;
  }
}