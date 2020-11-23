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
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _loseImage;
        [SerializeField] private Sprite _winImage;

        void Start()
        {
        }
        private void OnEnable()
        {
            if (GameManager.Instance.isWin)
                _image.sprite = _winImage;
            else
                _image.sprite = _loseImage;
        }
        // Update is called once per frame
        void Update()
        {
            
        }

        public void ShowStartCanvas()
        {
            GameManager.Instance.SetState(KPU.State.Initializing);
            NavigationalCanvasManager.Instance.ShowCanvas("Start");
        }
    }
}