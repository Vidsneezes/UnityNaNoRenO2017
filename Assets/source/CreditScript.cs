using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwiperEngine
{
    public class CreditScript : MonoBehaviour
    {
        public Button backButtons;

        private void Awake()
        {
            backButtons.onClick.AddListener(ToMainMenu);
        }

        private void ToMainMenu()
        {
            GameState.instance.ToMainMenu();
        }
    }
}