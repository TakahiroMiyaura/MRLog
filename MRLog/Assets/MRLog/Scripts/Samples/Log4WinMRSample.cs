// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using Com.Reseul.Log4MR.Commons;
using Com.Reseul.Log4MR.Unity;
using UnityEngine;

namespace Com.Reseul.Log4MR.Samples
{
    public class Log4WinMRSample : MonoBehaviour
    {
        // Use this for initialization
        private void Start()
        {
            MRLogSetting.Load().GetAwaiter().GetResult();

            MRLog.Debug("The cat can't fly in the sky.");
            MRLog.Info("The cat can't fly in the sky.");
            MRLog.Warn("The cat can't fly in the sky.");
            MRLog.Error("The cat can't fly in the sky.");
            MRLog.Fatal("The cat can't fly in the sky.");
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}
