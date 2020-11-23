using UnityEngine;

namespace Assets.Scenes.KindomRun.Scripts.Hurdle
{
    public class DynamicHurdleMove : MonoBehaviour
    {
        [SerializeField] private float speed = 0.05f;
        [SerializeField] private GameObject target;
        private Vector3 originalPos;
        private Vector3 targetPos;
        private bool isArrive = false;
        private Animator _animator;
        
        private void Awake()
        {
            originalPos = this.transform.position;
            targetPos = target.transform.position;
            _animator = GetComponentInChildren<Animator>();
        }


        // Update is called once per frame
        void Update()
        {
            if (!isArrive)
            {
                transform.LookAt(targetPos);
                transform.position = Vector3.MoveTowards(transform.position, 
                    targetPos, speed);

                if (Vector3.Distance(transform.position, targetPos) < 0.00001f)
                {
                    isArrive = true;
                }
            }
            else
            {
                target.transform.position = originalPos;
                originalPos = transform.position;
                targetPos = target.transform.position;
                isArrive = false;
            }

            _animator.SetFloat("Speed", Vector3.Magnitude(transform.position));
        }
    }
}
