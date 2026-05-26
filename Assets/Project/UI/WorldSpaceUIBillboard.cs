using UnityEngine;

public class WorldSpaceUIBillboard : MonoBehaviour
{
  private Transform cameraTr;



  void Awake()
  {
    cameraTr = Camera.main.transform; // cached camera transform once it starts
  }

  void LateUpdate()
  {
    Vector3 dir = cameraTr.position - transform.position;
    dir.y = 0f;

    if (dir.sqrMagnitude > 0)
    {
      Quaternion offset = Quaternion.LookRotation(dir);
      transform.rotation = offset;
      transform.forward = -dir; // It`s important to do if  canvas flipped;
    }

  }
}