using UnityEngine;

namespace Project.Scripts
{
    public class SlimeMovement : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier = 0.05f;
        private void Move()
        {
            transform.position += Vector3.forward * speedMultiplier;
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}
