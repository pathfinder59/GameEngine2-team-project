using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene.Ui
{
    public class PlayingCanvasUi : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventManager.On("game_ended", ShowEndCanvas);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.SetState(KPU.State.Paused);
                NavigationalCanvasManager.Instance.ShowCanvas("Pause");
                EventManager.Emit("game_paused");
            }
        }

        private void ShowEndCanvas(object obj)
        {
            GameManager.Instance.SetState(KPU.State.GameEnded);
            if(GameManager.Instance.State == KPU.State.Playing)
                NavigationalCanvasManager.Instance.ShowCanvas("End");           
        }
    }

}