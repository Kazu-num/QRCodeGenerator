using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{
    [RequireComponent(typeof(Button))]
    public class DeleteButton : MonoBehaviour
    {
        [SerializeField]
        InputField target;

        Button button;

        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Onclick);
        }

        void Onclick()
        {
            target.text = "";
        }
    }
}
