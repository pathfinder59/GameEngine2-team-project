using KPU.Manager;
using Scenes.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scene.Ui
{
    public class PlayingCanvasUi : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Transform playerPos;
        [SerializeField] private Transform enemyPos;
        
        private Player player;
        private Enemy enemy;
        // Start is called before the first frame update
        void Start()
        {
            EventManager.On("game_ended", ShowEndCanvas);
            slider.maxValue = player.Stat.MaxHp;
        }
        private void OnEnable()
        {
            player = ObjectPoolManager.Instance.Spawn("Player").GetComponent<Player>();
            player.gameObject.transform.position = playerPos.position;
            player.gameObject.transform.rotation = playerPos.rotation;

            enemy = ObjectPoolManager.Instance.Spawn("Enemy").GetComponent<Enemy>();
            enemy.gameObject.transform.position = enemyPos.position;
            enemy.gameObject.transform.rotation = enemyPos.rotation;
            enemy.ForwardTarget(null);
        }
        private void OnDisable()
        {
            if (player)
                player.gameObject.SetActive(false);
            if (enemy)
                enemy.gameObject.SetActive(false);
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
            slider.value = player.Stat.Hp;
        }

        private void ShowEndCanvas(object obj)
        {
            GameManager.Instance.SetState(KPU.State.GameEnded);
            NavigationalCanvasManager.Instance.ShowCanvas("End");

        }
    }

}