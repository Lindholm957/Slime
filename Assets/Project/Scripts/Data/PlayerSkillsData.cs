using System;
using UnityEngine;

namespace Project.Scripts.Data
{
    public class PlayerSkillsData : MonoBehaviour
    {
        public static PlayerSkillsData I { get; set; }
        [SerializeField] private float totalDamage;
        [SerializeField] private float attackSpeed;
        [SerializeField] private float healthPoints;

        public float TotalDamage => totalDamage;
        public float AttackSpeed => attackSpeed;
        public float HealthPoints => healthPoints;


        private void Awake()
        {
            I = this;
        }
        
    }
}