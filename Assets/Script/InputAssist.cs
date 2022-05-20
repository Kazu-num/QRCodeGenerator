using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QRCodeGenerator
{   
    public class InputAssist : MonoBehaviour
    {
        [SerializeField]
        GameObject buttonPrefab;

        [SerializeField]
        Transform buttonField;

        [SerializeField]
        InputField target;

        [SerializeField]
        List<string> assistStringList;

        [Header(" [additional] save system ")]

        [SerializeField]
        InputField editStrField;

        [SerializeField]
        Button editSaveButton;

        [SerializeField]
        Button editDeleteLastButton;

        const string KeySaveCount = "InputAssist_SaveCount";
        const string StrFaild = "Faild";

        void Awake()
        {
            if (buttonPrefab == null || buttonField == null || target == null) { return; }

            // load save data
            var count = PlayerPrefs.GetInt(KeySaveCount, 0);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var id = i + 1;
                    var str = PlayerPrefs.GetString(GetKey(id), StrFaild);
                    if (str != StrFaild)
                    {
                        assistStringList.Add(str);
                    }
                }
            }

            // generate button
            foreach (var str in assistStringList)
            {
                Add(str);
            }

            // additional save system
            if (editStrField == null || editSaveButton == null || editDeleteLastButton == null) { return; }

            editSaveButton.onClick.AddListener(() =>
            {
                var saveTxt = editStrField.text;
                Save(saveTxt);
                Add(saveTxt);
                Debug.Log($"save assist button. ({saveTxt})");

                editStrField.text = "";
            });

            editDeleteLastButton.onClick.AddListener(() =>
            {
                var deleted = DeleteLast();
                Debug.Log($"delete assist button. ({deleted})");


                var buttons = buttonField.GetComponentsInChildren<InputAssistButton>();
                foreach (var button in buttons)
                {
                    if (button.AssistString == deleted)
                    {
                        Destroy(button.gameObject);
                        break;
                    }
                }
            });
        }

        public void Add(string assistString)
        {
            var obj = Instantiate(buttonPrefab, buttonField);
            var btn = obj.GetComponent<InputAssistButton>();
            btn.Init(target, assistString);
        }

        public string GetKey(int id)
        {
            return string.Format("InputAssist_Save{0:0000}", id);
        }

        public void Save(string assistString)
        {
            var count = PlayerPrefs.GetInt(KeySaveCount, 0);

            count++;
            PlayerPrefs.SetString(GetKey(count), assistString);
            PlayerPrefs.SetInt(KeySaveCount, count);
        }

        public string DeleteLast()
        {
            var count = PlayerPrefs.GetInt(KeySaveCount, 0);
            if(count == 0) { return null; }

            var value = PlayerPrefs.GetString(GetKey(count));
            PlayerPrefs.DeleteKey(GetKey(count));
            count--;
            PlayerPrefs.SetInt(KeySaveCount, count);

            return value;
        }
    }
}
