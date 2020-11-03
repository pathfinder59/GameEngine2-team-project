using Scene.Ui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene.Ui
{
    public class StartCanvasUi : MonoBehaviour
    {

        public void ShowPlayingCanvas()
        {
            NavigationalCanvasManager.Instance.ShowCanvas("Playing");
        }
    }
}