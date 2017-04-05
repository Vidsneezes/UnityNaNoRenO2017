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
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();
            SpawnPanel();

        }

        public void SpawnPanel()
        {
            DialoguePanel dp = GameObject.Instantiate(leftPanelPrefab);
            dp.transform.SetParent(activePanelsHolder);
            dp.transform.localPosition = new Vector3(dp.transform.localPosition.x,activePanels.Count * panelHeight + panelPadding );
            dp.transform.localScale = new Vector3(1, 1, 1);
            activePanels.Add(dp);
        }

    }
}