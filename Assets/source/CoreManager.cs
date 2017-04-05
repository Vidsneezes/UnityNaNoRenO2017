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
            //TODO background parser

            //TODO music Parser

            //TODO music player

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
        public AudioManager audioManager;

        public string state;

        public List<CharacterProfileMeta> characters;
        public BackgroundObject backgrounds;
        public MusicObject musicObject;

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
            if(strip.background != "-")
            {
                SetBackground(strip.background);
            }

            if(strip.music != "-")
            {
                SetMusic(strip.music);
            }

            stripMeta.skit = strip.skit;
            stripMeta.text = strip.text;
            SetProfileMeta(strip.skit,strip.emotion);
            dp.coreManager = this;
            dp.transform.SetParent(activePanelsHolder);
            dp.transform.localScale = new Vector3(1, 1, 1);
            dp.transform.localPosition = new Vector3(0, -300, 0);
            Vector3 placePosition = new Vector3(0, panelPadding);
            dp.MoveLocally(placePosition);
            dp.ChangeCharacterSprite(stripMeta.sprite);
            dp.ChangeEmotionSpriteColor(stripMeta.color);
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

        public void SetProfileMeta(string characterName, string emotion)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].characterObject.name == characterName)
                {
                    stripMeta.sprite = characters[i].characterObject.GetSprite(emotion);
                    stripMeta.color = characters[i].characterObject.GetEmotionColor(emotion);
                }
            }
        }

        public void SetBackground(string backgroundName)
        {
            for (int i = 0; i < backgrounds.backgrounds.Count; i++)
            {
                if(backgrounds.backgrounds[i].name == backgroundName)
                {
                    backgroundImage.sprite = backgrounds.backgrounds[i].Image;
                    stripMeta.background = backgrounds.backgrounds[i].Image;
                }
            }
        }

        public void SetMusic(string musicName)
        {
            for (int i = 0; i < musicObject.musicList.Count; i++)
            {
                if (musicObject.musicList[i].name == musicName)
                {
                    audioManager.PlayClip(musicObject.musicList[i].audioClip);
                    stripMeta.music = musicObject.musicList[i].audioClip;
                }
            }
        }
    }

    public struct StripMeta
    {
        public string lastRealDirection;
        public string text;
        public string skit;
        public Sprite sprite;
        public Color color;
        public Sprite background;
        public AudioClip music;
    }

    [System.Serializable]
    public struct CharacterProfileMeta
    {
        public CharacterObject characterObject;
    }

}

