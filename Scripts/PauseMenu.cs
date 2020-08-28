using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Animator menuAnim;
    public Animator settingsAnim;

    bool settings=false;
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(paused){
            menuAnim.Play("PauseMenu");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            ui.SetActive(false);
            pauseMenu.SetActive(true);
            AudioListener.pause = true;
        }else{
            settings = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
            ui.SetActive(true);
            pauseMenu.SetActive(false);
            AudioListener.pause = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
        }
    }

    public void Resume(){
        paused = false;
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }

    public void QuitMain(){
        GameManager.instance.GoToMain();
    }

    IEnumerator SettingsMenu(){
        settings = !settings;
        if(settings){
            settingsMenu.SetActive(true);
            settingsAnim.Play("settings");
        }
        else if(!settings){
            settingsAnim.Play("settings_Reversed");
            yield return new WaitForSeconds(.5f);
            settingsMenu.SetActive(false);
        }
    }

    public void Settings(){
        StartCoroutine(SettingsMenu());
    }
}
