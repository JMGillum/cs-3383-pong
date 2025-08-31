using UnityEngine;
using UnityEngine.InputSystem;

public class quitManagerScript : MonoBehaviour
{
  public InputAction escape;
  
    void Start() {
      escape.Enable();
    }

    // Update is called once per frame
    void Update() {
        if (escape.WasPressedThisFrame()){
          Debug.Log("Quitting via Escape...");
          Application.Quit();
        }
    }
}
