using Project.Scripts.Data;
using Project.Scripts.Events.Base;
using Project.Scripts.Events.Systems;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class UIPlayerData : MonoBehaviour
    {
        [SerializeField] private TMP_Text softCoin;
        [Space]
        [SerializeField] private TMP_Text totalDamageLvl;
        [SerializeField] private TMP_Text totalDamageVal;
        [Space]
        [SerializeField] private TMP_Text attackSpeedLvl;
        [SerializeField] private TMP_Text attackSpeedVal;
        [Space]
        [SerializeField] private TMP_Text maxHealthPointsLvl;
        [SerializeField] private TMP_Text maxHealthPointsVal;

        private int _totalDamageLvl = 1;
        private int _attackSpeedLvl = 1; 
        private int _maxHealthPointsLvl = 1; 


        private void Awake()
        {
            GlobalEventSystem.I.Subscribe(EventNames.Data.SoftCoinChanged, OnSoftCoinChanged);
            GlobalEventSystem.I.Subscribe(EventNames.Data.TotalDamageChanged, OnTotalDamageChanged);
            GlobalEventSystem.I.Subscribe(EventNames.Data.AttackSpeedChanged, OnAttackSpeedChanged);
            GlobalEventSystem.I.Subscribe(EventNames.Data.MaxHealthPointsChanged, OnHealthPointsChanged);
        }
        
        private void OnSoftCoinChanged(GameEventArgs arg0)
        {
            softCoin.text = PlayerData.I.NumOfSoftCoins.ToString();
        }
        
        private void OnTotalDamageChanged(GameEventArgs arg0)
        {
            _totalDamageLvl++;

            totalDamageLvl.text = _totalDamageLvl.ToString();
            totalDamageVal.text = PlayerData.I.TotalDamage.ToString();
        }
        
        private void OnAttackSpeedChanged(GameEventArgs arg0)
        {
            _attackSpeedLvl++;

            attackSpeedLvl.text = _attackSpeedLvl.ToString();
            attackSpeedVal.text = PlayerData.I.AttackSpeed.ToString();
        }

        private void OnHealthPointsChanged(GameEventArgs arg0)
        {
            _maxHealthPointsLvl++;

            maxHealthPointsLvl.text = _maxHealthPointsLvl.ToString();
            maxHealthPointsVal.text = PlayerData.I.MaxHealthPoints.ToString();
        }

        private void OnDestroy()
        {
            GlobalEventSystem.I.Unsubscribe(EventNames.Data.SoftCoinChanged, OnSoftCoinChanged);
            GlobalEventSystem.I.Unsubscribe(EventNames.Data.TotalDamageChanged, OnTotalDamageChanged);
            GlobalEventSystem.I.Unsubscribe(EventNames.Data.AttackSpeedChanged, OnAttackSpeedChanged);
            GlobalEventSystem.I.Unsubscribe(EventNames.Data.MaxHealthPointsChanged, OnHealthPointsChanged);
        }
    }
}
