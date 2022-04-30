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
            if(buttonPrefab == null || buttonField == null || target == null) { return; }

            // load save data
            var count = PlayerPrefs.GetInt(KeySaveCount, 0);
            if (count > 0)
            {
                for(int i = 1; i < count - 1; i++)
                {
                    var str = PlayerPrefs.GetString(GetKey(i), StrFaild);
                    if(str != StrFaild)
                    {
                        assistStringList.Add(str);
                    }
                }
            }

            // generate button
            foreach(var str in assistStringList)
            {
                Add(str);
            }

            // additional save system
            if(editStrField == null || editSaveButton == null || editDeleteLastButton == null) { return; }

            editSaveButton.onClick.AddListener(() =>
            {
                Save(editStrField.text);
            });

            editDeleteLastButton.onClick.AddListener(() =>
            {
                DeleteLast();
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

        public void DeleteLast()
        {
            var count = PlayerPrefs.GetInt(KeySaveCount, 0);
            if(count <= 0) { return; }

            PlayerPrefs.DeleteKey(GetKey(count));
            count--;
            PlayerPrefs.SetInt(KeySaveCount, count);
        }
    }
}
