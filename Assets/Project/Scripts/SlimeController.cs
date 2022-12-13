using System;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts
{
    public class SlimeController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;
        [SerializeField] private int targetDistance;
        
        private float _destinationReachedThreshold = 0.5f;

        private SlimeState _curState = SlimeState.Idle;
        private Vector3 _targetPoint;
        private enum SlimeState
        {
            Idle,
            Moving,
            Attacking
        }

        private void Awake()
        {
            StartMoving();
        }

        private void OnEnemyBecameVisible()
        {
            StartAttack();
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
        }

        private void StartAttack()
        {
            _curState = SlimeState.Attacking;

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
    }
}
