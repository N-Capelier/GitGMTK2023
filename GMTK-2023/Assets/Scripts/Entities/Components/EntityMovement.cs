using System;
using UnityEngine;

namespace Runtime.Entities.Components
{
    public class EntityMovement : MonoBehaviour, IEntityComponent
    {
		private Entity _entity = null;
		public Entity Entity => _entity;

		[Header("Params")]
        [SerializeField]
        private float _moveSpeed = 5f;

		[Header("References")]
		[SerializeField]
		private Rigidbody _rigidbody;

		public void Initialize(Entity entity)
		{
			_entity = entity;

			_entity.Owner.InputManager.OnMovementInputChanged += OnMovementInputChanged;
		}

		private void OnDestroy()
		{
			_entity.Owner.InputManager.OnMovementInputChanged -= OnMovementInputChanged;
		}

		private void OnMovementInputChanged(Vector2 input)
		{
			_rigidbody.AddForce(new Vector3(input.x, 0f, input.y) * _moveSpeed, ForceMode.VelocityChange);
		}
	}
}