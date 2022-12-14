using System;
using Project.Scripts.Data;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using Project.Scripts.Game;
using Project.Scripts.UI;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private int maxHealthPoints;
        [SerializeField] private int numOfCoins = 47;
        [SerializeField] private int damage = 20;
        [SerializeField] private float attackSpeed = 1;

        private Transform _target;
        private int _healthPoints;
        private State _curState = State.Moving;

        private enum State
        {
            Moving,
            Attacking
        }
        
        private void Start()
        {
            _healthPoints = maxHealthPoints;
            
            healthBar.UpdateHealthBar(_healthPoints, maxHealthPoints);

            _target = GameManager.I.Slime.transform;

            navMesh.SetDestination(_target.position);
            GlobalEventSystem.I.SendEvent(EventNames.Enemy.BecameVisible,
                new GameEventArgs(gameObject));
        }

        private void StartAttacking()
        {
            _curState = State.Attacking;

            var repeatRate = 1 / attackSpeed;
            InvokeRepeating("Attack", 1, repeatRate);
        }

        private void Attack()
        {
            SendDamage(_target.gameObject);
        }
        
        private void SendDamage(GameObject hit)
        {
            hit.SendMessage("ApplyDamage", damage,
                    SendMessageOptions.DontRequireReceiver);
        }

        private void ApplyDamage(float damage)
        {
            _healthPoints -= Mathf.RoundToInt(damage);

            if (_healthPoints <= 0)
            {
                GlobalEventSystem.I.SendEvent(EventNames.Enemy.Died, new GameEventArgs(null));
                PlayerData.I.SoftCoinValChange(PlayerData.I.NumOfSoftCoins + numOfCoins);
                
                Destroy(gameObject);
            }
            else
            {
                healthBar.UpdateHealthBar(_healthPoints, PlayerData.I.MaxHealthPoints);
            }
        }

        private void Update()
        {
            if (_curState == State.Moving)
            {
                float distanceToTarget = Vector3.Distance(transform.position, _target.position);

                if (distanceToTarget < navMesh.stoppingDistance)
                {
                    navMesh.isStopped = true;
                    StartAttacking();
                }
            }
        }
    }
}