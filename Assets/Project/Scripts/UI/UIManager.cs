using Project.Scripts.Data;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {

        public void TotalDamageLvlUpClicked()
        {
            PlayerData.I.TotalDamageLvlUp();
        }
        
        public void AttackSpeedLvlUpClicked()
        {
            PlayerData.I.AttackSpeedLvlUp();
        }
        
        public void HealthPointsLvlUpClicked()
        {
            PlayerData.I.HealthPointsValChange();
        }
    }
}