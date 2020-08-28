using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator settingsAnim;
    public GameObject settingsMenu;
    bool settings=false;

    public void StartNewGame(){
        GameManager.instance.LoadGame();
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }

    IEnumerator SettingsMenu(){
        settings = !settings;
        if(settings){
            settingsMenu.SetActive(true);
            settingsAnim.Play("main_settings");
        }
        else if(!settings){
            settingsAnim.Play("main_settings_Reversed");
            yield return new WaitForSeconds(.5f);
            settingsMenu.SetActive(false);
        }
    }

    public void Settings(){
        StartCoroutine(SettingsMenu());
    }
}
