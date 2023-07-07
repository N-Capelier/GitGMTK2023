using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Entities.Components
{
	public class EntityAim : MonoBehaviour, IEntityComponent
	{
		private Entity _entity = null;
		public Entity Entity => _entity;

		public void Initialize(Entity entity)
		{
			_entity = entity;
		}
	}
}
