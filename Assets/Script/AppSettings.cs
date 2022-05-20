using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{
    public class AppSettings : MonoBehaviour
    {
        [SerializeField]
        int windowWidth = 540;

        [SerializeField]
        int windowHeight = 720;

        [SerializeField]
        Button resetWindowButton;

        void Awake()
        {
            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                ResetWindowSize();

                QualitySettings.SetQualityLevel(0); // very low

                resetWindowButton?.onClick.AddListener(ResetWindowSize);
            }
            else
            {
                QualitySettings.SetQualityLevel(0); // very low

                resetWindowButton?.gameObject.SetActive(false);
            }
        }

        public void ResetWindowSize()
        {
            Screen.SetResolution(windowWidth, windowHeight, false, 30);
        }
    }
}
