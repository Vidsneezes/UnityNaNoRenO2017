using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwiperEngine
{
    public class CutObject : ScriptableObject
    {
        public List<Strip> strips;
    }
}

[System.Serializable]
public struct Strip
{
    public string skit;
    public string emotion;
    public string text;
    public string direction;
    public string background;
    public string music;
}