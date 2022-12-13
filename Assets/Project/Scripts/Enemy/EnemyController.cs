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

        private Transform _target;

        private void Awake()
        {
            _target = GameManager.I.Slime.transform;

            navMesh.SetDestination(_target.position);
            GlobalEventSystem.I.SendEvent(EventNames.Enemy.BecameVisible,
                new GameEventArgs(gameObject));
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
    }
}