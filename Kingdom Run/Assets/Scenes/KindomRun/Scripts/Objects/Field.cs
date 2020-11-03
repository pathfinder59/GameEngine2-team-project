using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Object
{
    public class Field : MonoBehaviour
    {
        void Start()
        {
            EventManager.On("game_ended", Hide);
        }

        void Update()
        {

        }

        private void Hide(object obj) => gameObject.SetActive(false);
    }

}