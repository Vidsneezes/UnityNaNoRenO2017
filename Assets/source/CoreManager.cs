using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace SwiperEngine
{
    public class CoreManager : MonoBehaviour
    {

        //TODO add image parser
        
            //TODO Emotion parser

            //TODO background parser

            //TODO music Parser

            //TODO music player

            //TODO implement Text reader letter by letter

            //TODO finish state reducer

        public CoreLogic coreLogic;

        public DialoguePanel dialoguePanel;

        public DialoguePanel leftPanelPrefab;
        public DialoguePanel rightPanelPrefab;
        public Transform inactivePanelsHolder;
        public Transform activePanelsHolder;

        public TextMeshProUGUI skitName;
        public TextMeshProUGUI stripText;


        public float panelHeight;
        public float panelPadding;
        public Image backgroundImage;

        public string state;

        private List<DialoguePanel> activePanels;
        private List<DialoguePanel> inactivePanels;
        private StripMeta stripMeta;
        private List<DialoguePanel> tweeningPanels;

        private void Start()
        {
            activePanels = new List<DialoguePanel>();
            inactivePanels = new List<DialoguePanel>();
            tweeningPanels = new List<DialoguePanel>();
            state = "INITIAL";
        }

        private void Update()
        {
            switch (state)
            {
                case "INITIAL":SpawnPanel(); break;
                case "WORD_BY_WORD": if (Input.GetKeyDown(KeyCode.K))
                    {
                        state = "-";
                    }break;
                case "WAIT_SPAWN_TWEEN":
                    if (tweeningPanels.Count == 0)
                    {
                        StartCoroutine(WordByWordRoutine());
                    }
                    break;
                case "WAIT_INPUT":
                    if (coreLogic.endOfCut)
                    {
                        state = "LAST_CUT";
                    }

                    if (Input.GetKeyDown(KeyCode.K) && !coreLogic.endOfCut)
                    {
                        SpawnPanel();
                    }
                    break;
            }
        }

        public void SpawnPanel()
        {
            stripText.text = "";
            DialoguePanel dp = GameObject.Instantiate(dialoguePanel);
            Strip strip = coreLogic.NextStrip();
            if(strip.direction != "-")
            {
                stripMeta.lastRealDirection = strip.direction;
                dp.AlignImage(strip.direction);
            }else
            {
                dp.AlignImage(stripMeta.lastRealDirection);  
            }
            stripMeta.skit = strip.skit;
            stripMeta.text = strip.text;
            dp.coreManager = this;
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

        private IEnumerator WordByWordRoutine()
        {
            skitName.text = stripMeta.skit;
            string text = stripMeta.text;
            string[] words = text.Split(' ');
            string fillThis = "";
            int wordCounter = 0;
            state = "WORD_BY_WORD";
            while (wordCounter < words.Length)
            {
                if (state == "WORD_BY_WORD")
                {

                    fillThis += words[wordCounter] + " ";
                    wordCounter += 1;
                    stripText.text = fillThis;
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    stripText.text = text;
                    break;
                }
            }
            yield return new WaitForSeconds(0.05f);
            state = "WAIT_INPUT";
        }
    }

    public struct StripMeta
    {
        public string lastRealDirection;
        public string text;
        public string skit;
    }

}

