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

		private WeaponSO _currentWeapon = null;

		public void Initialize(Entity entity)
		{
			_entity = entity;
		}

		public void SetWeapon(WeaponSO weapon)
		{
			if(_currentWeapon != null)
				Destroy(_currentWeapon);

			_currentWeapon = weapon;
		}
	}
}
