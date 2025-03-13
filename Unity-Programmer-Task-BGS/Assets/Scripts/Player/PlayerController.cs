using UnityEngine;
using UnityEngine.InputSystem;

namespace BGS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _cc;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _turnSmoothVelocity;
        [SerializeField] private float _turnSmoothTime;

        private Vector3 _currentMotion;

        private void Update()
        {
            _animator.SetFloat("Velocity", _currentMotion.magnitude);

            if (_currentMotion.magnitude >= 0.1f)   //brackeys 3d cc
            {
                float targetAngle = Mathf.Atan2(_currentMotion.x, _currentMotion.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(_cc.transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                _cc.transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _cc.Move(moveDir.normalized * _playerSpeed * Time.deltaTime);
            }
        }

        private void OnMove(InputValue action)
        {
            Vector2 actionValue = action.Get<Vector2>();

            _currentMotion = new Vector3(actionValue.x, 0, actionValue.y);
        }

        private Vector3 GetRelativeMovement()
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f;
            cameraForward = cameraForward.normalized;

            Vector3 cameraRight = Camera.main.transform.right;
            cameraRight.y = 0f;
            cameraRight = cameraRight.normalized;

            return cameraForward * _currentMotion.z + cameraRight * _currentMotion.x;
        }
    }
}