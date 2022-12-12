using System;
using UnityEngine;

namespace Project.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager I { get; set; }
        [SerializeField] private GameObject slime;

        public GameObject Slime => slime;

        private void Awake()
        {
            I = this;
        }
    }
}