using Project.Scripts.Data;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Slime
{
    public class SlimeController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private Shooting.Shooting shooting;
        [SerializeField] private int targetDistance;

        private float _destinationReachedThreshold = 0.5f;

        private SlimeState _curState = SlimeState.Idle;
        private Vector3 _targetPoint;
        private int _healthPoints = 110;
        private enum SlimeState
        {
            Idle,
            Moving,
            Attacking
        }

        public int HealthPoints => _healthPoints;

        private void Awake()
        {
            StartMoving();
            
            GlobalEventSystem.I.Subscribe(EventNames.Enemy.BecameVisible, OnEnemyBecameVisible);
            GlobalEventSystem.I.Subscribe(EventNames.Enemy.Died, OnEnemyDied);
            GlobalEventSystem.I.Subscribe(EventNames.Data.MaxHealthPointsChanged,
                OnMaxHealthPointsChanged);
        }

        private void OnEnemyBecameVisible(GameEventArgs arg)
        {
            // StartAttack();
        }
        
        private void OnMaxHealthPointsChanged(GameEventArgs arg)
        {
            _healthPoints += PlayerData.I.MaxHealthPointsUpValue;
        }

        private void OnEnemyDied(GameEventArgs arg)
        {
            shooting.StopShooting();

            StartMoving();
        }

        private void StartMoving()
        {
            _curState = SlimeState.Moving;

            _targetPoint = transform.position + Vector3.forward * targetDistance;
            navMesh.SetDestination(_targetPoint);
        }

        private void StopAndAwait()
        {
            _curState = SlimeState.Idle;
            GlobalEventSystem.I.SendEvent(EventNames.Slime.Stopped,
                new GameEventArgs(null));
        }

        private void StartAttack()
        {
            _curState = SlimeState.Attacking;
            shooting.StartShooting(PlayerData.I.AttackSpeed);
        }
        
        private void ApplyDamage(int damage)
        {
            if ((_healthPoints -= damage) <= 0)
            {
                Destroy(gameObject);
            }
        }
        

        private void Update()
        {
            if (_curState == SlimeState.Moving)
            {
                float distanceToTarget = Vector3.Distance(transform.position, _targetPoint);

                if (distanceToTarget < _destinationReachedThreshold)
                {
                    StopAndAwait();
                }
            }
        }

        private void OnDestroy()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Enemy.BecameVisible,
                OnEnemyBecameVisible);
            GlobalEventSystem.I.Unsubscribe(EventNames.Enemy.Died, OnEnemyDied);
            GlobalEventSystem.I.Unsubscribe(EventNames.Data.MaxHealthPointsChanged,
                OnEnemyBecameVisible);
        }
    }
}
