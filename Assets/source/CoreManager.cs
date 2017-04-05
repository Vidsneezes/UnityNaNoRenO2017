﻿using System.Collections;
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

        private List<DialoguePanel> activePanels;
        private List<DialoguePanel> inactivePanels;

        private void Start()
        {
            activePanels = new List<DialoguePanel>();
            inactivePanels = new List<DialoguePanel>();
            SpawnPanel();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SpawnPanel();
            }
        }

        public void SpawnPanel()
        {
            DialoguePanel dp = GameObject.Instantiate(leftPanelPrefab);
            dp.transform.SetParent(activePanelsHolder);
            dp.transform.localScale = new Vector3(1, 1, 1);
            dp.transform.localPosition = new Vector3(0, -300, 0);
            Vector3 placePosition = new Vector3(0, panelPadding);
            dp.transform.DOLocalMove(placePosition, 0.3f).SetEase(Ease.OutBack);
            ShiftOtherPanelsUp();
            activePanels.Add(dp);
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
            dp.transform.DOLocalMove(newPos, 0.3f).SetEase(Ease.OutCirc);
        }

    }
}