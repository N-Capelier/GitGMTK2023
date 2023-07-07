using UnityEngine;

namespace Runtime.Entities.Components
{
    public class EntityInteraction : MonoBehaviour, IEntityComponent
    {
		private Entity _entity = null;
		public Entity Entity => _entity;

		public void Initialize(Entity entity)
        {
			_entity = entity;

			_entity.Owner.InputManager.OnInteract += Interact;
		}

		private void OnDestroy()
		{
			_entity.Owner.InputManager.OnInteract -= Interact;
		}

		private void Interact()
		{

		}
	}
}