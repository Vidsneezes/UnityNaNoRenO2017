using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SwiperEngine
{
    public class MainMenuScript : MonoBehaviour
    {
        public Button startGameButton;
        public Button instructionButton;
        public Button cancelButtons;

        public Image background;

        public GameObject instructionsPanel;

        private void Awake()
        {
            instructionsPanel.SetActive(false);
            startGameButton.onClick.AddListener(ToGame);
            startGameButton.transform.DOLocalMoveY(1.2f, 0.3f).SetRelative().SetLoops(-1, LoopType.Yoyo);
            instructionButton.onClick.AddListener(ViewInstructions);
            instructionButton.transform.DOLocalMoveY(2.5f, 0.2f).SetRelative().SetLoops(-1, LoopType.Yoyo);
            cancelButtons.onClick.AddListener(CloseInstructions);
            background.transform.DOScale(new Vector3(0.03f, 0.03f, 0.03f), 1.2f).SetRelative().SetLoops(-1, LoopType.Yoyo);
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