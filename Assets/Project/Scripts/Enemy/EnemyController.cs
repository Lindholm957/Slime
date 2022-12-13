using System;
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

        private Transform _target;

        private void Awake()
        {
            _target = GameManager.I.Slime.transform;

            navMesh.SetDestination(_target.position);
            GlobalEventSystem.I.SendEvent(EventNames.Enemy.BecameVisible,
                new GameEventArgs(gameObject));
        }
    }
}