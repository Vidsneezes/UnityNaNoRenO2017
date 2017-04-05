using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwiperEngine
{
    [System.Serializable]
    public class CoreLogic 
    {
        public CutObject cutObject; //main entry point of game
        public int currentStrip;
        public bool endOfCut;

        public CoreLogic()
        {
            currentStrip = 0;
        }

        public Strip NextStrip()
        {
            Strip next = cutObject.strips[currentStrip];
            currentStrip += 1;
            return next;
        }
        
    }
}