using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SwiperEngine
{
    public class BootLoader : MonoBehaviour
    {
        public GameState gameStatePrefab;
        private void Awake()
        {
            GameObject.Instantiate(gameStatePrefab);
            GameObject.Destroy(gameObject);
        }
    }
}