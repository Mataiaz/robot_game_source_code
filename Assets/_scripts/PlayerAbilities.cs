using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
  PlayerMovement pm;
  PlayerCamera playerCamera;

  private float abilityActive = 0;

  public GameObject movement_component;
  public GameObject vision_component;
  public GameObject sound_component;
  public GameObject drilling_component;
  public GameObject defense_component;
  public GameObject inactive_movement_component;
  public GameObject inactive_vision_component;
  public GameObject inactive_sound_component;
  public GameObject inactive_drilling_component;
  public GameObject inactive_defense_component;

  private bool abilty1 = false; // movement
  private bool abilty2 = false; // vision
  private bool abilty3 = false; // sound
  private bool abilty4 = false; // drilling
  private bool abilty5 = false; // defense
  private bool canFix = false; // defense

  private GameObject box = null;

  public GameObject turnOfCamera;
  public static bool isProtected = false;
  void Start() {
    pm = GetComponent<PlayerMovement>();
    playerCamera = GetComponent<PlayerCamera>();
    abilty2 = true;
    abilityActive = 1;

    // disable movement
    pm.stunned = true;
    // disable vision
    //turnOfCamera.SetActive(false);
    // disable sound
    AudioListener.volume = 0;
    // disable drill
    // code for drilling
    // disable defense
    // code for defense
  }
  void Update() {

    abilites();

}

private void abilites() {
  if (abilityActive > 2) {
      abilityActive = 0;
      abilty1       = false;
      abilty2       = false;
      abilty3       = false;
      abilty4       = false;
      abilty5       = false;
    }

    // movement
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      if (abilityActive < 2 || abilty1 == true) {
        if (abilty1 == true)
          abilityActive -= 1;
        else
          abilityActive += 1;
          abilty1       = !abilty1;
        pm.stunned = !pm.stunned;
        movement_component.SetActive(!movement_component.activeSelf);
        inactive_movement_component.SetActive(!inactive_movement_component.activeSelf);
      }
    }
    
    // vision
    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      if (abilityActive < 2 || abilty2 == true) {
        if (abilty2 == true)
          abilityActive -= 1;
        else
          abilityActive += 1;
          abilty2       = !abilty2;
          turnOfCamera.SetActive(!turnOfCamera.activeSelf);
          vision_component.SetActive(!vision_component.activeSelf);
          inactive_vision_component.SetActive(!inactive_vision_component.activeSelf);
      }
    }
    
    // sound
    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      if (abilityActive < 2 || abilty3 == true) {
        if (abilty3 == true)
          abilityActive -= 1;
        else
          abilityActive += 1;
          abilty3       = !abilty3;
        if (AudioListener.volume == 0)
          AudioListener.volume = 1.0f;
        else
          AudioListener.volume = 0;
        sound_component.SetActive(!sound_component.activeSelf);
        inactive_sound_component.SetActive(!inactive_sound_component.activeSelf);
      }
    }
    
    // drill
    if (Input.GetKeyDown(KeyCode.Alpha4)) {
      Debug.Log(abilityActive);
      Debug.Log(abilty4);
      if (abilityActive < 2 || abilty4 == true) {
        if (abilty4 == true)
          abilityActive -= 1;
        else
        abilityActive += 1;
        abilty4       = !abilty4;
        drilling_component.SetActive(!drilling_component.activeSelf);
        inactive_drilling_component.SetActive(!inactive_drilling_component.activeSelf);
        if (canFix) {
          Destroy(box);
        }
      }
    }
    
    // defense
    if (Input.GetKeyDown(KeyCode.Alpha5)) {
      if (abilityActive < 2 || abilty5 == true) {
        if (abilty5 == true)
          abilityActive -= 1;
        else
          abilityActive += 1;
        isProtected = !isProtected;
        abilty5       = !abilty5;
        if(abilty2) {
          abilityActive = 1;
          abilty2       = false;
        }
        defense_component.SetActive(!defense_component.activeSelf);
        inactive_defense_component.SetActive(!inactive_defense_component.activeSelf);
      }

    }
  }
  private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "boxxx") {
          canFix = true;
          box = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "boxxx") {
          canFix = false;
          box = null;
        }
    }
}