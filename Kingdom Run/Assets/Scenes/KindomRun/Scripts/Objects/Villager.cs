using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Object
{
    public class Villager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            void Start()
            {
                EventManager.On("game_ended", Hide);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void Hide(object obj) => gameObject.SetActive(false);
    }
}