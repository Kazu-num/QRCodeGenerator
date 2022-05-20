using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QRCodeGenerator
{
    public class SwitchActive : MonoBehaviour
    {
        [SerializeField]
        GameObject[] gameObjects;

        bool[] activeOnStart;

        private void Start()
        {
            if (gameObjects.Length == 0) { return; }

            activeOnStart = new bool[gameObjects.Length];

            for (int i = 0; i < gameObjects.Length; i++)
            {
                activeOnStart[i] = gameObjects[i].activeSelf;
            }
        }

        public void Switch(GameObject obj)
        {
            obj.SetActive(!obj.activeSelf);
        }

        public void ActiveOne(GameObject target)
        {
            if (target.gameObject.activeSelf)
            {
                // reset start state
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(activeOnStart[i]);
                }
            }
            else
            {
                // active target and hide other
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    if (gameObjects[i] == target)
                    {
                        gameObjects[i].SetActive(true);
                    }
                    else
                    {
                        gameObjects[i].SetActive(false);
                    }
                }
            }
        }
    }
}
