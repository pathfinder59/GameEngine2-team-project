using KPU.Manager;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scenes.KindomRun.Scripts.Character
{
    public class PlayerController : MonoBehaviour, PlayerInputAction.IPlayerActions
    {
        private PlayerInputAction _inputAction;
        private Vector2 _inputVector;
        private CharacterController _characterController;
        private Animator _animator;

        private float _fallingSpeed;
        private bool _isGround;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform groundCheckPos;

        [SerializeField] private float characterMoveSpeed = 10f;
        [SerializeField] private float characterRotateSpeed = 5f;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponentInChildren<Animator>();
        }
        
        private void OnEnable()
        {
            if (_inputAction == null)
                _inputAction = new PlayerInputAction();
            
            _inputAction.Player.SetCallbacks(this);
            _inputAction.Player.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        private void Update()
        {
            if (!(_inputVector.x == 0 && _inputVector.y == 0))
            {
                Vector3 direction = new Vector3(_inputVector.x, 0, _inputVector.y);
                var rotate = Quaternion.LookRotation(direction);
                transform.rotation =
                    Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * characterRotateSpeed);
                _characterController.Move(transform.forward * Time.deltaTime * characterMoveSpeed);
            }
            
            _animator.SetFloat("Speed", 
                Mathf.Max(Mathf.Abs(_inputVector.x), Mathf.Abs(_inputVector.y)));


            _isGround = Physics.CheckSphere(groundCheckPos.position, 0.1f, layerMask);
            if (!_isGround)
            {
                _characterController.Move(new Vector3(0, -0.98f * Time.deltaTime, 0));
            }

            Vector3 viewPos = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);
            
            if (viewPos.y < 0.0f || viewPos.y > 0.99f)
            {
                GameManager.Instance.SetEndState(false);
                EventManager.Emit("game_ended");
            }
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            _inputVector = context.ReadValue<Vector2>();
        }
    }
}
