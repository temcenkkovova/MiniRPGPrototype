using UnityEngine;

public class BloodEffectSpawner : MonoBehaviour
{
  public ParticleSystem bloodEffectPrefab;

  public void Spawn(Vector3 hitPosition)
  {

    Quaternion rotation = hitPosition.sqrMagnitude > 0.001f ? Quaternion.LookRotation(hitPosition) : Quaternion.identity;
    ParticleSystem effect = Instantiate(bloodEffectPrefab, hitPosition, rotation);
    effect.Play();
    Destroy(effect.gameObject, 0.5f);
  }
}