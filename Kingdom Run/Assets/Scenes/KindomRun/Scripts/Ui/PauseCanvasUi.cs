using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene.Ui
{
    public class PauseCanvasUi : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ShowPlayingCanvas()
        {
            GameManager.Instance.SetState(KPU.State.Playing);
            NavigationalCanvasManager.Instance.ShowCanvas("Playing");
            EventManager.Emit("game_resumed");
        }
        public void ShowStartCanvas()
        {
            GameManager.Instance.SetState(KPU.State.Initializing);
            NavigationalCanvasManager.Instance.ShowCanvas("Start");
            EventManager.Emit("game_ended");
        }
    }
}