using Runtime.Weapons;
using UnityEngine;

namespace Runtime.Entities.Components
{
    public class EntityInteraction : MonoBehaviour, IEntityComponent
    {
		private Entity _entity = null;
		public Entity Entity => _entity;

		[Header("Params")]
		[SerializeField]
		LayerMask _itemLayerMask = default;

		static LayerMask _entityLayerMask = LayerMask.NameToLayer("EntityItem");

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
			if (Physics.Raycast(_entity.transform.position, -_entity.transform.up, out RaycastHit hitInfo, 10f, _entityLayerMask))
			{
				_entity.Aim.SetWeapon(hitInfo.collider.GetComponent<WeaponItem>().GetWeapon());
			}
			else if (Physics.Raycast(_entity.transform.position, -_entity.transform.up, out hitInfo, 10f, _itemLayerMask))
			{
				_entity.Aim.SetWeapon(hitInfo.collider.GetComponent<WeaponItem>().GetWeapon());
			}
		}
	}
}