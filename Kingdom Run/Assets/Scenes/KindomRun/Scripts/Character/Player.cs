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
        [SerializeField] private GameObject aura_particle;
        
        private NavMeshAgent _agent;
        private PlayerState _state;
        private Coroutine _damageRoutine;
        private bool _isdamagable;
        private bool _isShield = false;
        private SkinnedMeshRenderer _renderer;
        public PlayerState State => _state;
        public float Hp => stat.Hp;
        public float MaxHp => stat.MaxHp;
        private float shieldTime = 2.0f;
        private Coroutine _shieldRoutine;
        
        public Stat Stat => stat;

        private void Start()
        {
            EventManager.On("game_ended", Hide);
            EventManager.On("using_heal", OnUseHeal);
            EventManager.On("using_shield", OnUseShield);
        }
        private void Awake()
        {
            //_agent = GetComponent<NavMeshAgent>();
            _renderer = GetComponent<SkinnedMeshRenderer>();
            aura_particle.SetActive(false);
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
                    GameManager.Instance.SetEndState(false);
                    EventManager.Emit("game_ended");
                }
            }
            else if(other.gameObject.CompareTag("Portal"))
            {
                GameManager.Instance.SetEndState(true);
                EventManager.Emit("game_ended");          
            }
        }

        public void Damage(float damageAmount)
        {
            if (!_isdamagable) return;

            if (!_isShield)
            {
                if (_shieldRoutine != null)
                    StopCoroutine(_shieldRoutine);
                _damageRoutine = StartCoroutine(DamageRoutine(damageAmount));
            }
            else
            {
                _shieldRoutine = StartCoroutine(ShieldRoutine());
            }
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
            noDamageTime = 0.5f;
        }

        private void Hide(object obj) => gameObject.SetActive(false);
        
        private void OnUseHeal(object obj)
        {
            stat.AddHp(20); // 20 회복
        }
        
        private void OnUseShield(object obj)
        {
            _isShield = true;
            aura_particle.SetActive(true);
        }

        IEnumerator ShieldRoutine()
        {
            yield return new WaitForSeconds(shieldTime);
            _isShield = false;
            aura_particle.SetActive(false);
        }
    }
}