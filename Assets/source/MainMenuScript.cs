using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwiperEngine
{
    public class MainMenuScript : MonoBehaviour
    {
        public Button startGameButton;
        public Button instructionButton;
        public Button cancelButtons;

        public GameObject instructionsPanel;

        private void Awake()
        {
            instructionsPanel.SetActive(false);
            startGameButton.onClick.AddListener(ToGame);
            instructionButton.onClick.AddListener(ViewInstructions);
            cancelButtons.onClick.AddListener(CloseInstructions);
        }

        public void ToGame()
        {
            startGameButton.onClick.RemoveAllListeners();
            GameState.instance.ToCoreScene();
        }

        public void ViewInstructions()
        {
            instructionsPanel.gameObject.SetActive(true);
        }

        public void CloseInstructions()
        {
            instructionsPanel.gameObject.SetActive(false);
        }
    }
}