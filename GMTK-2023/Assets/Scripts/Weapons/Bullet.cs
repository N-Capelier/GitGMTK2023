using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Weapons
{
    public class Bullet : MonoBehaviour
    {
        protected WeaponSO _weapon = null;

        [Header("References")]
        protected Rigidbody _rigidBody = null;

        protected bool _initialized = false;

        protected Vector3 _direction = Vector3.zero;

        public void Initialize(WeaponSO weapon, Vector3 direction)
        {
            _weapon = weapon;
            _direction = direction;
            _initialized = true;
        }
	}
}
