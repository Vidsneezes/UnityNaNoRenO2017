using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwiperEngine
{
    [CreateAssetMenu(fileName = "Musical Profile", menuName = "SwiperEngine/MusicalProfile", order = 2)]
    public class MusicObject : ScriptableObject
    {
        public List<MusicStruct> musicList;

        [ContextMenu("Re Assign Names")]
        public void AssignNames()
        {
            for (int i = 0; i < musicList.Count; i++)
            {
                musicList[i] = new MusicStruct(musicList[i].audioClip.name, musicList[i].audioClip);
            }
        }
    }

    [System.Serializable]
    public struct MusicStruct
    {
        public string name;
        public AudioClip audioClip;

        public MusicStruct(string _name, AudioClip _auCl)
        {
            name = _name;
            audioClip = _auCl;
        }
    }
}