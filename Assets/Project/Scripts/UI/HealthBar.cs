using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Image healthBarImage;
        [SerializeField] TMP_Text healthValue;

        private int _maxHealth;
        private int _health;
        private Quaternion startRotation;
        
        private void Start() {
            startRotation = transform.rotation;
        }
        private void Update() {
            transform.rotation = startRotation;
        }
        
        public void UpdateHealthBar(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
            
            if (_health < _maxHealth / 2)
            {
                healthBarImage.color = Color.red;
            }
            Debug.Log((float)_health / _maxHealth);
            healthBarImage.fillAmount = Mathf.Clamp((float)_health / _maxHealth, 0, 1f);

            healthValue.text = _health.ToString();
        }
    }
}