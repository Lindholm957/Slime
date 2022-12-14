using System;
using System.Collections.Generic;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; set; }
        [SerializeField] private GameObject slime;
        [SerializeField] private float enemySpawnDistance;
        [SerializeField] private List<GameObject> enemyPrefabs;

        private GameObject _enemy;
        private int _waveNum = 1;

        public GameObject Slime => slime;

        private void Awake()
        {
            I = this;
            GlobalEventSystem.I.Subscribe(EventNames.Slime.Stopped, OnSlimeStopped);
            GlobalEventSystem.I.Subscribe(EventNames.Enemy.Died, OnEnemyDied);
        }

        private void OnSlimeStopped(GameEventArgs arg0)
        {
            var slimePosition = slime.transform.position;
            
            var enemyZSpawnPoint = new Vector3(slimePosition.x, 0, slimePosition.z + enemySpawnDistance);
            
            if (_waveNum <= enemyPrefabs.Count)
            {
                _enemy = Instantiate(enemyPrefabs[_waveNum - 1]);
            }
            else
            {
                _enemy = Instantiate(enemyPrefabs[enemyPrefabs.Count-1]);
            }

            _enemy.GetComponent<NavMeshAgent>().Warp(enemyZSpawnPoint);
        }
        
        private void OnEnemyDied(GameEventArgs arg0)
        {
            ++_waveNum;
        }

        private void OnDestroy()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Slime.Stopped, OnSlimeStopped);
            GlobalEventSystem.I.Unsubscribe(EventNames.Enemy.Died, OnEnemyDied);
        }
    }
}