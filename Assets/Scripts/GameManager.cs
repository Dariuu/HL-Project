using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public GameObject fadeScreen;
    int ActiveScene;

    public float mouseSensitivity;
    public float qualityLevel;
    public float volume;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive));
        ActiveScene = (int)SceneIndexes.TITLE_SCREEN;
        StartCoroutine("GetSceneLoadProgress");
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadGame(){
        loadingScreen.gameObject.SetActive(true);
        ActiveScene = (int)SceneIndexes.TEST;

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TEST, LoadSceneMode.Additive));

        StartCoroutine("GetSceneLoadProgress");
    }

    public void GoToMain(){
        loadingScreen.gameObject.SetActive(true);
        ActiveScene = (int)SceneIndexes.TITLE_SCREEN;

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TEST));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive));

        StartCoroutine("GetSceneLoadProgress");
    }

    public IEnumerator GetSceneLoadProgress(){
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(ActiveScene));
        loadingScreen.gameObject.SetActive(false);
        fadeScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        fadeScreen.SetActive(false);
    }
}
