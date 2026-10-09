using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace
{
    public class HelthController : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        public float _currentHealth;
        private float _maxHealth = 100;
        public float _damageAmount;
        private void Awake()
        {

            _currentHealth = _maxHealth;

        }



        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            if (GameManager.Instance.playerController.IsDead)
            {
                _currentHealth = _maxHealth;
            } ;
                UpdateHelthBar();
        }

        private void UpdateHelthBar()
        {
            _healthBar.value = _currentHealth;
        }
    }

}

