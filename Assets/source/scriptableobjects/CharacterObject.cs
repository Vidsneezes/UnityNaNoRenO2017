using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwiperEngine
{
    [CreateAssetMenu(fileName = "Character Profile", menuName = "SwiperEngine/CharacterProfile", order = 0)]
    public class CharacterObject : ScriptableObject
    {
        public List<EmotionStruct> emotions;

        public Sprite GetSprite(string emotion)
        {
            for (int i = 0; i < emotions.Count; i++)
            {
                if(emotion == emotions[i].name)
                {
                    return emotions[i].sprite;
                }
            }

            return emotions[0].sprite;
        }

        public Color GetEmotionColor(string emotion)
        {
            for (int i = 0; i < emotions.Count; i++)
            {
                if (emotion == emotions[i].name)
                {
                    return emotions[i].color;
                }
            }

            return emotions[0].color;

        }
    }

    [System.Serializable]
    public struct EmotionStruct
    {
        public string name;
        public Sprite sprite;
        public Vector2 offset;
        public Vector2 size;
        public Color color;
    }
}