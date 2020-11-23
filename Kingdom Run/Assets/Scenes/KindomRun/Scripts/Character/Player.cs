namespace Scenes.AI
{
    using KPU.Manager;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;

    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private Stat stat;
        [SerializeField] private float noDamageTime = 0.5f;

        private NavMeshAgent _agent;
        private PlayerState _state;
        private Coroutine _damageRoutine;
        private bool _isdamagable;
        private SkinnedMeshRenderer _renderer;

        public PlayerState State => _state;
        public float Hp => stat.Hp;
        public float MaxHp => stat.MaxHp;


        public Stat Stat => stat;

        private void Start()
        {
            EventManager.On("game_ended", Hide);
        }
        private void Awake()
        {
            //_agent = GetComponent<NavMeshAgent>();
            _renderer = GetComponent<SkinnedMeshRenderer>();
        }

        private void OnEnable()
        {
            _isdamagable = true;
            stat.AddHp(stat.MaxHp);
        }

        private void OnDisable()
        {
            if (_damageRoutine != null) StopCoroutine(_damageRoutine);
        }

        private void Update()
        {

        }

        private void OnTriggerStay(Collider other)
        {
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Barrier"))
            {
                Damage(25);
                if (Stat.Hp == 0)
                {
                    EventManager.Emit("game_ended");
                }
            }
            else if(other.gameObject.CompareTag("Portal"))
            {
                EventManager.Emit("game_ended");
            }
        }

        public void Damage(float damageAmount)
        {
            if (!_isdamagable) return;
            _damageRoutine = StartCoroutine(DamageRoutine(damageAmount));
        }

        private IEnumerator DamageRoutine(float damageAmount)
        {
            stat.AddHp(-damageAmount);
          //  var material = _renderer.material;
          //  var defaultColor = material.color;

           // material.color = new Color(1, 1, 1, 0.5f);
            _isdamagable = false;

            yield return new WaitForSeconds(noDamageTime);

           // material.color = defaultColor;
            _isdamagable = true;
        }

        private void Hide(object obj) => gameObject.SetActive(false);
    }
}