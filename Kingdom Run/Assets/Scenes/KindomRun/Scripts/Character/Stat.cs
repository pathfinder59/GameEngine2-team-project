namespace Scenes.AI
{
    using System;
    using UnityEngine;

    [Serializable]
    public struct Stat
    {
        [SerializeField] private float _maxHp;

        private float _hp;

        public Stat(float maxHp = 10, float maxMp = 10)
        {
            _maxHp = maxHp;
            _hp = maxHp;
        }

        public float MaxHp => _maxHp;

        public float Hp => _hp;

        public void AddHp(float hpAmount)
        {
            _hp = Mathf.Clamp(_hp + hpAmount, 0, _maxHp);
        }
    }
}