using Runtime.Weapons;
using UnityEngine;
using Runtime.Audio;

namespace Runtime.Entities.Components
{
    public class EntityInteraction : MonoBehaviour, IEntityComponent
    {
		private Entity _entity = null;
		public Entity Entity => _entity;

		[Header("Params")]
		[SerializeField]
		LayerMask _itemLayerMask = default;

		private LayerMask _entityLayerMask;

		private void Start()
		{
			_entityLayerMask = LayerMask.NameToLayer("EntityItem");
		}

		public void Initialize(Entity entity)
        {
			_entity = entity;

			_entity.Owner.InputManager.OnInteract += Interact;
		}

		public void Kill()
		{
			_entity.Owner.InputManager.OnInteract -= Interact;
		}

		private void Interact()
		{
			if (Physics.Raycast(_entity.transform.position, -_entity.transform.up, out RaycastHit hitInfo, 10f, _entityLayerMask))
			{
				_entity.Aim.SetWeapon(hitInfo.collider.GetComponent<WeaponItem>().GetWeapon());
				//MANAGE SFX
				int randomID = Random.Range(1, 4);
				AudioManager.Instance.PlayAudio("WeaponPickup" + randomID);
			}
			else if (Physics.Raycast(_entity.transform.position, -_entity.transform.up, out hitInfo, 10f, _itemLayerMask))
			{
				_entity.Aim.SetWeapon(hitInfo.collider.GetComponent<WeaponItem>().GetWeapon());
				//MANAGE SFX
				int randomID = Random.Range(1, 4);
				AudioManager.Instance.PlayAudio("WeaponPickup" + randomID);
			}
		}
	}
}