using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace SwiperEngine
{
    public class CoreLogicTest
    {

        [Test]
        public void CanParseAndUseNextStripOfCoreLogic()
        {
            string[] dialogueTest = { "Me[s]I want some coffee[s]#neutral[s]$right[s]/nightsky[s]!TheStart", "Me[s]ugghh, I don't want to get up though[s]#angry" };

            CoreLogic coreLogic = new CoreLogic();
            CutObject cutObject = CutCreatorEditor.GetCutFromStringArray(dialogueTest);

            coreLogic.cutObject = cutObject;

            Strip nextStrip = coreLogic.NextStrip();
            Assert.AreEqual("I want some coffee", nextStrip.text);
            nextStrip = coreLogic.NextStrip();
            Assert.AreEqual("ugghh, I don't want to get up though", nextStrip.text);
        }

        [Test]
        public void IsAwareWhenCutIsFinished()
        {
            string[] dialogueTest = { "Me[s]I want some coffee[s]#neutral[s]$right[s]/nightsky[s]!TheStart", "Me[s]ugghh, I don't want to get up though[s]#angry" };

            CoreLogic coreLogic = new CoreLogic();
            CutObject cutObject = CutCreatorEditor.GetCutFromStringArray(dialogueTest);

            coreLogic.cutObject = cutObject;

            Strip nextStrip = coreLogic.NextStrip();
            Assert.AreEqual("I want some coffee", nextStrip.text);
            nextStrip = coreLogic.NextStrip();
            Assert.AreEqual("ugghh, I don't want to get up though", nextStrip.text);
            Assert.AreEqual(true, coreLogic.endOfCut);
        }



    }
}