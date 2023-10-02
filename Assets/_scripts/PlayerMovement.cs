using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Rigidbody entityBody;
  private Vector3 movementInput;
  public float currentSpeed;
  public bool stunned = false;



  PlayerCamera playerCamera;
  [SerializeField] private GameObject characterCamera;
  private void Start() {
    currentSpeed = 10;
    playerCamera = GetComponent<PlayerCamera>();
    entityBody = GetComponent<Rigidbody>();
  }
  private void Update() {
    if (!stunned)
        Movement();
    playerCamera.CameraMovement(characterCamera, this.gameObject);
    
  }

  private void Movement() {
      DoAction();
      movementInput = Quaternion.Euler(0f, characterCamera.transform.eulerAngles.y, 0f) * new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
  }

  private void DoAction() {
    if (entityBody != null && movementInput != null)
      entityBody.MovePosition(transform.position + movementInput * Time.deltaTime * currentSpeed);
  }

}