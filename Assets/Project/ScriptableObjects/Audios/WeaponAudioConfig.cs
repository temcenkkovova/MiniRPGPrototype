using UnityEngine;
[CreateAssetMenu(menuName = "Audio/Weapon")]

public class WeaponAudioConfig : ScriptableObject
{
  public AudioClip[] shootClips;
  public AudioClip[] missClips;
  public float volume = 1f;
  public float pitchMin = 0.95f;
  public float pitchMax = 1.05f;
}