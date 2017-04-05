using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwiperEngine
{
    public class CoreManager : MonoBehaviour
    {
        public CoreLogic coreLogic;

        public DialoguePanel leftPanelPrefab;
        public DialoguePanel rightPanelPrefab;
        public Transform inactivePanelsHolder;
        public Transform activePanelsHolder;

        public float panelHeight;
        public float panelPadding;

        private List<DialoguePanel> activePanels;
        private List<DialoguePanel> inactivePanels;

        private void Start()
        {
            activePanels = new List<DialoguePanel>();
            inactivePanels = new List<DialoguePanel>();
        }

        public void SpawnPanel()
        {

        }

    }
}