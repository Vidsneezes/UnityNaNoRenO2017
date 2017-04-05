using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwiperEngine
{
    [CreateAssetMenu(fileName = "Background Profile", menuName = "SwiperEngine/BackgroundProfile", order = 1)]
    public class BackgroundObject : ScriptableObject
    {
        public List<BackgroundStruct> backgrounds;

        [ContextMenu("Re Assign Names")]
        public void AssignNames()
        {
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgrounds[i] =new BackgroundStruct( backgrounds[i].Image.name,backgrounds[i].Image);
            }
        }
    }

    [System.Serializable]
    public struct BackgroundStruct
    {
        public string name;
        public Sprite Image;

        public BackgroundStruct(string _name, Sprite _im)
        {
            name = _name;
            Image = _im;
        }
    }
}