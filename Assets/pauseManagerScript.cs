using UnityEngine;
using UnityEngine.InputSystem;

public class pauseManagerScript : MonoBehaviour
{
  public InputAction toggle;
  public GameObject pauseMenuUI;
  public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
      toggle.Enable();
      this.resume();
    }

    // Update is called once per frame
    void Update() {
       if (toggle.WasPressedThisFrame()){
         Debug.Log("Pause menu toggled");
           if (isPaused) {
             resume();
           } else {
             pause();
           }
       } 
    }
    
    public void resume() {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1F;
      isPaused = false;
    }

    public void pause() {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0F;
      isPaused = true;
    }

    public void quit() {
      Debug.Log("Quitting via Pause Menu...");
      Application.Quit();
    }
}
