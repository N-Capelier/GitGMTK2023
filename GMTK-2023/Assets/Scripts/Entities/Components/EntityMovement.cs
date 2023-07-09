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
		public Rigidbody _rigidbody;



		public void Initialize(Entity entity)
		{
			_entity = entity;

			_entity.Owner.InputManager.OnMovementInputChanged += OnMovementInputChanged;
		}

		public void Kill()
		{
			_entity.Owner.InputManager.OnMovementInputChanged -= OnMovementInputChanged;
		}

        private void OnMovementInputChanged(Vector2 input)
		{
				//transform.Translate(new Vector3(input.x, 0f, input.y) * _moveSpeed);
				_rigidbody.velocity = (new Vector3(input.x, 0f, input.y) * _moveSpeed);
		}
	}
}