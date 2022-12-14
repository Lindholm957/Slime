using System;
using Project.Scripts.Data;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using Project.Scripts.Game;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private float healthPoints;
        [SerializeField] private int numOfCoins = 47;
        [SerializeField] private int damage = 20;
        [SerializeField] private float attackSpeed = 1;

        private Transform _target;
        private State _curState = State.Moving;

        private enum State
        {
            Moving,
            Attacking
        }
        
        private void Awake()
        {
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
            if ((healthPoints -= damage) <= 0)
            {
                GlobalEventSystem.I.SendEvent(EventNames.Enemy.Died, new GameEventArgs(null));
                PlayerData.I.SoftCoinValChange(PlayerData.I.NumOfSoftCoins + numOfCoins);
                
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (_curState == State.Moving)
            {
                float distanceToTarget = Vector3.Distance(transform.position, _target.position);

                if (distanceToTarget < navMesh.stoppingDistance)
                {
                    StartAttacking();
                }
            }
        }
    }
}