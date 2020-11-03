using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scene.Ui
{
    public class EndCanvasUi : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private Image image;
        [SerializeField] private Sprite loseImage;
        [SerializeField] private Sprite winImage;
        void Start()
        {
            EventManager.On("game_win", SetWinScene);
            EventManager.On("game_lose", SetLoseScene);
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void SetWinScene(object obj)
        {
            
            image.sprite = winImage;
        }
        private void SetLoseScene(object obj)
        {
            image.sprite = loseImage;
        }
        public void ShowStartCanvas()
        {
            GameManager.Instance.SetState(KPU.State.Initializing);
            NavigationalCanvasManager.Instance.ShowCanvas("Start");
        }
    }
}