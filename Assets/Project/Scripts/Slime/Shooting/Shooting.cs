using Project.Scripts.Data;
using UnityEngine;

namespace Project.Scripts.Slime.Shooting
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject ballPrefab;

        public void StartShooting(float attackSpeed)
        {
            var repeatRate = 1 / attackSpeed;
            InvokeRepeating("Shoot", 1, repeatRate);
        }
        
        private void Shoot()
        {
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<BallMove>().SetBallDamage(PlayerSkillsData.I.TotalDamage);
        }
    }
}