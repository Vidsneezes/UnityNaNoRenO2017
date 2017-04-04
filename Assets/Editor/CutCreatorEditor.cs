using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SwiperEngine
{
    public class CutCreatorEditor : EditorWindow
    {
        [MenuItem("CreateCut",menuItem = "CutEditor/CreateCut")]
        public static void CreateCutObject()
        {
            string path = Application.dataPath + "/data/dialogue.txt";
            string[] dialogues = File.ReadAllLines(path);

            CutObject mm = new CutObject();
            AssetDatabase.CreateAsset(mm, "Assets/cut.asset");
        }

    }
}