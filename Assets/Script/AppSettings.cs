using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QRCodeGenerator
{
    public class AppSettings : MonoBehaviour
    {
        [SerializeField]
        int windowWidth = 540;

        [SerializeField]
        int windowHeight = 720;

        void Awake()
        {
            Screen.SetResolution(windowWidth, windowHeight, false, 30);

            QualitySettings.SetQualityLevel(0); // very low
        }
    }
}
