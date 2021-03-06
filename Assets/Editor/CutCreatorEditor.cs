﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SwiperEngine
{
    public class CutCreatorEditor : EditorWindow
    {
        public static CutObject GetCutFromStringArray(string[] dialogues)
        {
            string[] separators = new string[] { "[s]" };

            CutObject cutObject = (CutObject)ScriptableObject.CreateInstance(typeof(CutObject));
            cutObject.strips = new List<Strip>();
            for (int i = 0; i < dialogues.Length; i++)
            {
                Strip strip;
                string[] split = dialogues[i].Split(separators, StringSplitOptions.None);
                strip.skit = split[0];
                strip.text = split[1];
                strip.emotion = "-";
                strip.direction = "-";
                strip.music = "-";
                strip.background = "-";

                for (int j = 2; j < split.Length; j++)
                {
                    if (split[j].Contains("#"))
                    {
                        strip.emotion = split[j].Split(new char[] { '#' })[1];
                    }
                    else if (split[j].Contains("$"))
                    {
                        strip.direction = split[j].Split(new char[] { '$' })[1];
                    }
                    else if (split[j].Contains("/"))
                    {
                        strip.background = split[j].Split(new char[] { '/' })[1];
                    }
                    else if (split[j].Contains("!"))
                    {
                        strip.music = split[j].Split(new char[] { '!' })[1];
                    }
                }
                cutObject.strips.Add(strip);
            }
            return cutObject;
        }

        [MenuItem("CreateCut",menuItem = "CutEditor/CreateCut")]
        public static void CreateCutObject()
        {
            string path = Application.dataPath + "/GameData/dialogue.txt";
            string[] dialogues = File.ReadAllLines(path);
            CutObject cutObject = GetCutFromStringArray(dialogues);
            AssetDatabase.CreateAsset(cutObject, "Assets/cut.asset");
        }

    }
}