using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Profile", menuName = "SwiperEngine/CharacterProfile",order = 0)]
public class CharacterObject : ScriptableObject {
    public List<EmotionStruct> emotions;
}

[System.Serializable]
public struct EmotionStruct
{
    public string name;
    public Sprite sprite;
    public Vector2 offset;
    public Color color;
}
