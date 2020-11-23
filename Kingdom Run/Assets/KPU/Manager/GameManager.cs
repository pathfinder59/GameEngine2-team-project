using UnityEngine;

namespace KPU.Manager
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        [SerializeField] private State state;

        public bool isWin = false;
        public State State => state;

        /// <summary>
        /// state 설정.
        /// </summary>
        /// <param name="targetState">게임의 상태</param>
        public void SetState(State targetState)
        {
            state = targetState;
        }

        public void SetEndState(bool b) => isWin = b;
        private void Start()
        {
            state = State.Initializing;
            
            EventManager.On("game_started", o => SetState(State.Playing));
            EventManager.On("game_ended", o => SetState(State.GameEnded));
            EventManager.On("game_paused", o => SetState(State.Paused));
            EventManager.On("game_resumed", o => SetState(State.Playing));
        }
    }
}