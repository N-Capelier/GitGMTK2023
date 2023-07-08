using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Weapons;
using UnityEngine;

namespace Runtime.Entities.Components
{
	public class EntityAim : MonoBehaviour, IEntityComponent
	{
		private Entity _entity = null;
		public Entity Entity => _entity;

		[SerializeField]
		private WeaponSO _defaultWeapon = null;

		private WeaponSO _currentWeapon = null;

		CountdownTimer _weaponCooldownTimer = new();
		private bool _canShoot = true;

		public void Initialize(Entity entity)
		{
			_entity = entity;

			_entity.Owner.InputManager.OnAimInputChanged += Aim;
		}

		public void SetWeapon(WeaponSO weapon)
		{
			if (_currentWeapon != null)
				Destroy(_currentWeapon);

			_currentWeapon = weapon;
		}

		private void Aim(Vector2 input)
		{
			if (input == Vector2.zero)
				return;

			if (!_canShoot)
				return;

			if (_currentWeapon != null)
			{
				_canShoot = false;
				_weaponCooldownTimer.SetTime(_currentWeapon.Cooldown, () => _canShoot = true);
				ShootWithWeapon(_currentWeapon, input);
			}
			else if (_defaultWeapon != null)
			{
				_canShoot = false;
				_weaponCooldownTimer.SetTime(_defaultWeapon.Cooldown, () => _canShoot = true);
				ShootWithWeapon(_defaultWeapon, input);
			}
		}

		private void ShootWithWeapon(WeaponSO weapon, Vector2 direction)
		{
			weapon.Shoot(transform.position, direction);
		}
	}
}
