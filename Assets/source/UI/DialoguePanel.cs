using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SwiperEngine
{
    public class DialoguePanel : MonoBehaviour
    {

        public Image characterSprite;
        public Image emotionPanel;

        public void ChangeCharacterSprite(Sprite newSprite)
        {
            characterSprite.sprite = newSprite;
            //Reset width
        }

        public void ChangeEmotionSpriteColor(Color color)
        {
            emotionPanel.color = color;
        }
    }
}