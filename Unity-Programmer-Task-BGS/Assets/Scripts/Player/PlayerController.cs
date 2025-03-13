using UnityEngine;
using UnityEngine.InputSystem;

namespace BGS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _cc;
        [SerializeField] private float _playerSpeed;

        private Vector3 currentMotion;

        private void Update()
        {
            _cc.SimpleMove(GetRelativeMovement() * _playerSpeed);
        }

        private void OnMove(InputValue action)
        {
            Vector2 actionValue = action.Get<Vector2>();

            currentMotion = new Vector3(actionValue.x, 0, actionValue.y);
        }

        private Vector3 GetRelativeMovement()
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f;
            cameraForward = cameraForward.normalized;

            Vector3 cameraRight = Camera.main.transform.right;
            cameraRight.y = 0f;
            cameraRight = cameraRight.normalized;

            return cameraForward * currentMotion.z + cameraRight * currentMotion.x;
        }
    }
}