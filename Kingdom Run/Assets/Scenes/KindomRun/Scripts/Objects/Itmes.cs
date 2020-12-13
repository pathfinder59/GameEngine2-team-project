using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itmes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.On("game_ended", Hide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void Hide(object obj) => gameObject.SetActive(false);
}
