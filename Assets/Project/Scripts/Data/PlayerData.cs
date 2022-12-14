using System;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using UnityEngine;

namespace Project.Scripts.Data
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData I { get; set; }
        
        [SerializeField] private float totalDamageUpValue;
        [SerializeField] private float attackSpeedUpValue;
        [SerializeField] private int maxHealthPointsUpValue;

        private int _numOfSoftCoins = 0;
        private float _totalDamage = 10f;
        private float _attackSpeed = 1f;
        private int _maxHealthPoints = 110;
        
        public int NumOfSoftCoins => _numOfSoftCoins;
        public float TotalDamage => _totalDamage;
        public float AttackSpeed => _attackSpeed;
        public int MaxHealthPoints
        {
            get => _maxHealthPoints;
            set => _maxHealthPoints = value;
        }
        public int MaxHealthPointsUpValue => maxHealthPointsUpValue;


        private void Awake()
        {
            I = this;
        }

        public void SoftCoinValChange(int newValue)
        {
            _numOfSoftCoins = newValue;
            GlobalEventSystem.I.SendEvent(EventNames.Data.SoftCoinChanged,
                new GameEventArgs(null));
        }
        
        public void TotalDamageLvlUp()
        {
            _totalDamage += totalDamageUpValue;
            GlobalEventSystem.I.SendEvent(EventNames.Data.TotalDamageChanged,
                new GameEventArgs(null));
        }
        
        public void AttackSpeedLvlUp()
        {
            _attackSpeed += attackSpeedUpValue;
            GlobalEventSystem.I.SendEvent(EventNames.Data.AttackSpeedChanged,
                new GameEventArgs(null));
        }
        
        public void HealthPointsValChange()
        {
            _maxHealthPoints += maxHealthPointsUpValue;
            GlobalEventSystem.I.SendEvent(EventNames.Data.MaxHealthPointsChanged,
                new GameEventArgs(null));
        }
        
    }
}