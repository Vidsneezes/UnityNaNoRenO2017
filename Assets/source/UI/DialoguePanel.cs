using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

        public void MoveLocally(Vector3 newPosition, float duration = 0.3f)
        {
            transform.DOLocalMove(newPosition, duration).SetEase(Ease.OutBack);
        }
    }
}