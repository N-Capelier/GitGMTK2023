using System;
using Runtime.Audio;
using UnityEngine;

namespace Runtime.HealthSystem
{
    public class HealthBar : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private int _maxHealthPoints = 10;
        public int MaxHealthPoints => _maxHealthPoints;

        private int _currentHealthPoints = 10;
        public int CurrentHealthPoints => _currentHealthPoints;

        private Action _onDeath = null;

        public void Initialize(Action onDeath)
        {

        }

        public void TakeDamage(int amount)
        {
            _currentHealthPoints = Mathf.Max(0, _currentHealthPoints - amount);

            if(_currentHealthPoints <= 0f)
				_onDeath?.Invoke();
        }
    }
}
