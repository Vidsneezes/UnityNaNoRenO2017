using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwiperEngine
{
    public class GameState : MonoBehaviour
    {

        private static GameState gameState;

        public static GameState instance
        {
            get
            {
                if (!gameState)
                {
                    gameState = FindObjectOfType(typeof(GameState)) as GameState;

                    if (!gameState)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                    }
                }

                return gameState;
            }
        }

        public string state;
        public string activeScene;
        public Camera loadCamera;

        public AudioManager audioManager;

        // Use this for initialization
        void Start()
        {
            if (state == "BOOT")
            {
                ToMainMenu();
            }
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void UnloadPrevious()
        {
            if (activeScene != "-")
            {
                SceneManager.UnloadSceneAsync(activeScene);
            }
            loadCamera.gameObject.SetActive(true);
        }

        public void ToMainMenu()
        {
            UnloadPrevious();
            StartCoroutine(LoadScenAsyncRoutine("MainMenu", "MAIN_MENU"));
        }

        public void ToCoreScene()
        {
            UnloadPrevious();
            StartCoroutine(LoadScenAsyncRoutine("CoreScene", "CORE"));
        }

        public void ToCredits()
        {
            UnloadPrevious();
            StartCoroutine(LoadScenAsyncRoutine("Credits", "CREDITS"));
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
            activeScene = sceneName;
            loadCamera.gameObject.SetActive(false);

        }
    }
}