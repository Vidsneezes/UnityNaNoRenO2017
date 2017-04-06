using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    public string state;
    public string activeScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
      
	}



    public void ToMainMenu()
    {
        SceneManager.UnloadSceneAsync(activeScene);
        activeScene = "MainMenu";
    }

    IEnumerator LoadScenAsyncRoutine(string sceneName, string futureState)
    {
        AsyncOperation asyncOpDone = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncOpDone.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        //loadCamera.gameObject.SetActive(false);
        state = futureState;

    }
}
