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
        public CoreManager coreManager;

        public void ChangeCharacterSprite(Sprite newSprite)
        {
            characterSprite.sprite = newSprite;
            //Reset width
        }

        public void ChangeEmotionSpriteColor(Color color)
        {
            emotionPanel.color = color;
        }

        public void AlignImage(string alignment)
        {
            switch (alignment)
            {
                case "right":
            characterSprite.rectTransform.localPosition = new Vector3(100, characterSprite.rectTransform.localPosition.y, 0);
                    break;
                case "left":
            characterSprite.rectTransform.localPosition = new Vector3(-100, characterSprite.rectTransform.localPosition.y, 0);
                    break;
                case "center":
            characterSprite.rectTransform.localPosition = new Vector3(0, characterSprite.rectTransform.localPosition.y, 0);
                    break;
            }
        }

        public void MoveLocally(Vector3 newPosition, float duration = 0.3f)
        {
            transform.DOLocalMove(newPosition, duration).SetEase(Ease.OutBack).OnComplete(OnDoneMove);
        }

        private void OnDoneMove()
        {
            coreManager.RemoveTween(this);
        }
    }
}