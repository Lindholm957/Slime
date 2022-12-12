using System;
using Project.Scripts.Game;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMesh;

        private Transform _target;

        private void OnEnable()
        {
            _target = GameManager.I.Slime.transform;

            navMesh.SetDestination(_target.position);
        }
    }
}