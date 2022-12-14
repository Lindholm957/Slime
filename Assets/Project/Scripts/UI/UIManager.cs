using Project.Scripts.Data;
using Project.Scripts.Game;
using Project.Scripts.Slime;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text totalDamagePriceText;
        [SerializeField] private TMP_Text attackSpeedPriceText;
        [SerializeField] private TMP_Text healthPointsPriceText;
        [Space] 
        [SerializeField] private float priceLvlUpMultiplier = 1.5f;
        
        private int _totalDamagePrice = 15;
        private int _attackSpeedPrice = 15;
        private int _healthPointsPrice = 15;
        
        public void TotalDamageLvlUpClicked()
        {
            if (PlayerData.I.NumOfSoftCoins >= _totalDamagePrice)
            {
                PlayerData.I.SoftCoinValChange(PlayerData.I.NumOfSoftCoins - _totalDamagePrice);
                
                _totalDamagePrice = Mathf.RoundToInt(_totalDamagePrice * priceLvlUpMultiplier);

                totalDamagePriceText.text = _totalDamagePrice.ToString();
                    
                PlayerData.I.TotalDamageLvlUp();
            }
        }
        
        public void AttackSpeedLvlUpClicked()
        {
            if (PlayerData.I.NumOfSoftCoins >= _attackSpeedPrice)
            {
                PlayerData.I.SoftCoinValChange(PlayerData.I.NumOfSoftCoins - _attackSpeedPrice);
                
                _attackSpeedPrice = Mathf.RoundToInt(_attackSpeedPrice * priceLvlUpMultiplier);

                attackSpeedPriceText.text = _attackSpeedPrice.ToString();

                PlayerData.I.AttackSpeedLvlUp();
            }
        }
        
        public void HealthPointsLvlUpClicked()
        {
            if (PlayerData.I.NumOfSoftCoins >= _healthPointsPrice)
            {
                PlayerData.I.SoftCoinValChange(PlayerData.I.NumOfSoftCoins - _healthPointsPrice);

                _healthPointsPrice = Mathf.RoundToInt(_healthPointsPrice * priceLvlUpMultiplier);

                healthPointsPriceText.text = _healthPointsPrice.ToString();

                PlayerData.I.HealthPointsValChange();
            }
        }
    }
}