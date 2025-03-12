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
            _cc.SimpleMove(currentMotion * _playerSpeed);
        }

        private void OnMove(InputValue action)
        {
            Vector2 actionValue = action.Get<Vector2>();

            currentMotion = new Vector3(actionValue.x, 0, actionValue.y);
        }
    }
}