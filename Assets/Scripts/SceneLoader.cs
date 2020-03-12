using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject Board;
    public GameObject SceneRoot;
    public Text progress;
    public void loadScene()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
        //async.allowSceneActivation = false;
        while (!async.isDone)
        {
            yield return new WaitForSeconds(0.1f);
            progress.text = async.progress.ToString();
        }
        //async.allowSceneActivation = true;
        GameObject[] g;
        g = GameObject.FindGameObjectsWithTag("Ship");
        foreach (var gi in g)
            gi.SetActive(false);
        SceneManager.MoveGameObjectToScene(Board, SceneManager.GetSceneByBuildIndex(1));
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().setBoard(Board);
        //SceneRoot.SetActive(false);

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(0));
    }
}
