using System;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{
    public class DebugLogUI : MonoBehaviour
    {
        [SerializeField]
        Text textUI;

        [SerializeField]
        string header = ">> DEBUG LOG <<";

        void Awake()
        {
            if (textUI == null)
            {
                textUI = GetComponent<Text>();
                if (textUI == null) { return; }
            }

            textUI.text = header;

            Application.logMessageReceived += LogReceived;
        }

        void OnDestroy()
        {
            Application.logMessageReceived -= LogReceived;
        }

        void LogReceived(string condition, string stackTrace, LogType type)
        {
            string log = condition;
            switch (type)
            {
                case LogType.Error:
                case LogType.Exception:
                    log = "<color=#ff0000>" + condition + Environment.NewLine + stackTrace + "</color>"; // red
                    break;
                case LogType.Assert:
                case LogType.Warning:
                    log = "<color=#ffff00>" + condition + Environment.NewLine + stackTrace + "</color>"; // yellow
                    break;
                default:
                    break;
            }

            textUI.text += Environment.NewLine + log;
        }
    }
}
