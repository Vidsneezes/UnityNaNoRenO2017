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

public struct Strip
{
    public enum Direction
    {
        right,
        left
    }

    public string skit;
    public string emotion;
    public string text;
    public Direction left;
    public string background;
    public string music;
}