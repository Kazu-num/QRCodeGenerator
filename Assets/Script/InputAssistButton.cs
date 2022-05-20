using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{
    [RequireComponent(typeof(Button))]
    public class InputAssistButton : MonoBehaviour
    {
        public string AssistString { get { return assistString; } }

        string assistString;

        InputField target;

        Button button;

        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Onclick);
        }

        void Onclick()
        {
            target.text += assistString;
        }

        public void Init(InputField target, string str)
        {
            this.target = target;
            this.assistString = str;

            button.gameObject.GetComponentInChildren<Text>().text = str;
        }
    }
}
