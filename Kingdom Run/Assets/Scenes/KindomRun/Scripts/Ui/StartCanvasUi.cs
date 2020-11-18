﻿using KPU.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene.Ui
{
    public class StartCanvasUi : MonoBehaviour
    {

        private void Start()
        {
            EventManager.On("game_started", SpawnPlayingScene);
        }
        public void ShowPlayingCanvas()
        {
            GameManager.Instance.SetState(KPU.State.Playing);
            NavigationalCanvasManager.Instance.ShowCanvas("Playing");
            EventManager.Emit("game_started");
        }
        private void SpawnPlayingScene(object obj)
        {
            ObjectPoolManager.Instance.Spawn("Field");
            ObjectPoolManager.Instance.Spawn("Barriers");
        }
    }
}