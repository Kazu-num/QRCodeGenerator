using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{
    public class AppController : MonoBehaviour
    {
        [SerializeField]
        InputField inputField;

        [SerializeField]
        RawImage qrcodeRawImage;

        void Start()
        {
            inputField.onEndEdit.AddListener(UpdateQRCode);
        }

        void UpdateQRCode(string str)
        {
            try
            {
                qrcodeRawImage.texture = QRCodeUtil.Generate(str);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
                return;
            }

            Debug.LogFormat("UpdateQRCode: [{0}]", str);
        }
    }
}