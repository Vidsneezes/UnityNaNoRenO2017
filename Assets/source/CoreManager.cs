using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        public Image backgroundImage;

        public string state;

        private List<DialoguePanel> activePanels;
        private List<DialoguePanel> inactivePanels;

        private List<DialoguePanel> tweeningPanels;

        private void Start()
        {
            activePanels = new List<DialoguePanel>();
            inactivePanels = new List<DialoguePanel>();
            tweeningPanels = new List<DialoguePanel>();
        }

        private void Update()
        {
           

            switch (state)
            {
                case "INITIAL":SpawnPanel(); break;
                case "WAIT_SPAWN_TWEEN":
                    if (tweeningPanels.Count == 0)
                    {
                        state = "WAIT_INPUT";
                    }
                    break;
                case "WAIT_INPUT":
                    if (Input.GetKeyDown(KeyCode.K))
                    {
                        SpawnPanel();
                    }
                    break;
            }
        }

        public void SpawnPanel()
        {
            DialoguePanel dp = GameObject.Instantiate(leftPanelPrefab);
            dp.transform.SetParent(activePanelsHolder);
            dp.transform.localScale = new Vector3(1, 1, 1);
            dp.transform.localPosition = new Vector3(0, -300, 0);
            Vector3 placePosition = new Vector3(0, panelPadding);
            dp.MoveLocally(placePosition);
            tweeningPanels.Add(dp);
            ShiftOtherPanelsUp();
            activePanels.Add(dp);

            state = "WAIT_SPAWN_TWEEN";

        }

        public void ShiftOtherPanelsUp()
        {
            for (int i = 0; i < activePanels.Count; i++)
            {
                ShiftPanel(activePanels[i]);
            }
        }
     
        private void ShiftPanel(DialoguePanel dp)
        {
            Vector3 newPos = dp.transform.localPosition;
            newPos.y += panelHeight;
            dp.MoveLocally(newPos);
            tweeningPanels.Add(dp);
        }

        public void RemoveTween(DialoguePanel dp)
        {
            tweeningPanels.Remove(dp);
        }
    }
}