using UnityEngine;
using Runtime.HealthSystem;

namespace Runtime.Weapons
{
    public class SwordBullet : Bullet
    {
		private void FixedUpdate()
		{
			if (!_initialized)
				return;

			_rigidBody.velocity = _direction * _weapon.MoveSpeed;
		}

		private void OnTriggerEnter(Collider other)
		{
			other.GetComponentInParent<HealthBar>().TakeDamage(_weapon.Damages);
		}
	}
}
