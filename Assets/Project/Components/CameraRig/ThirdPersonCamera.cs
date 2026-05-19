using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
  public Transform cameraTransform;
  public Transform target; // It`s  a player;

  private float distance = 5f;
  private float height = 2f;
  private float mouseSensitivity = 3f;
  private float followSmooth = 10f;

  private float minPitch = -20f; // min corner camera 
  private float maxPitch = 60f; // max corner camera 

  private float yaw;
  private float pitch = 20f;

  void LateUpdate()
  {
    if (target == null || cameraTransform == null) return;

    FollowTarget();

    if (Input.GetMouseButton(1))
    {
      RotateCamera();
    }

    ApplyCameraPosition();
  }

  private void FollowTarget()
  {
    Vector3 targetPos = target.position;
    transform.position = Vector3.Lerp(transform.position, targetPos, followSmooth * Time.deltaTime);
  }

  private void RotateCamera()
  {
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");
    yaw += mouseX * mouseSensitivity; // rotate on the right or left
    pitch -= mouseY * mouseSensitivity; // rotate top or down
    pitch = Mathf.Clamp(pitch, minPitch, maxPitch); // Control top down camera rotation 
  }

  private void ApplyCameraPosition()
  {
    Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
    Vector3 offset = rotation * new Vector3(0f, height, -distance);
    cameraTransform.position = transform.position + offset;
    cameraTransform.LookAt(transform.position + Vector3.up * height);
  }
}