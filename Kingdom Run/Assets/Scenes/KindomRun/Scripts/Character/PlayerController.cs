using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Assets.Scenes.KindomRun.Scripts.Character
{
    public class PlayerController : MonoBehaviour, PlayerInputAction.IPlayerActions
    {
        private PlayerInputAction _inputAction;
        private Vector2 _inputVector;
        private CharacterController _characterController;
        private Animator _animator;
        
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
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            _inputVector = context.ReadValue<Vector2>();
        }
    }
}
