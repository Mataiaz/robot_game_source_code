using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  public float mouseSensitivity = 2f;
  private float rotationX;
  private float rotationY;
  // rotate our camera
  public void CameraMovement(GameObject characterCamera, GameObject characterBody) {
    float moveX = Input.GetAxis("Horizontal");
    float moveZ = Input.GetAxis("Vertical");
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    rotationX -= mouseY;
    rotationX = Mathf.Clamp(rotationX, -90f, 10f);
    rotationY += mouseX;
    characterCamera.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    characterBody.transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
  }
}
