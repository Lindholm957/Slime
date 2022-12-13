using System;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using UnityEngine;

namespace Project.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; set; }
        [SerializeField] private GameObject slime;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float enemySpawnDistance;

        private GameObject _enemy;

        public GameObject Slime => slime;

        private void Awake()
        {
            I = this;
            GlobalEventSystem.I.Subscribe(EventNames.Slime.Stopped, OnSlimeStopped);
        }

        private void OnSlimeStopped(GameEventArgs arg0)
        {
            var slimePosition = slime.transform.position;
            
            var enemyZSpawnPoint = new Vector3(slimePosition.x,
                slimePosition.y, slimePosition.z + enemySpawnDistance); 
            
            _enemy = Instantiate(enemyPrefab, enemyZSpawnPoint, Quaternion.Euler(0, 0, 0));
        }

        private void OnDestroy()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Slime.Stopped, OnSlimeStopped);
        }
    }
}