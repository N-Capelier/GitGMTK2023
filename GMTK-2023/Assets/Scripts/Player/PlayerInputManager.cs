using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Player
{
	public class PlayerInputManager : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		PlayerInput _playerInput = null;
		InputAction _movementAction = null;
		InputAction _aimAction = null;
		InputAction _interactAction = null;

		private Vector2 _lastMovementInput = Vector2.zero;
		private Vector2 _currentMovementInput = Vector2.zero;

		private Vector2 _lastAimInput = Vector2.zero;
		private Vector2 _currentAimInput = Vector2.zero;

		public event Action<Vector2> OnMovementInputChanged;
		public event Action<Vector2> OnAimInputChanged;
		public event Action OnInteract;

		private void OnEnable()
		{
			RegisterEventHandlers();
		}

		private void FixedUpdate()
		{
			UpdateMovementInput();
			UpdateAimInput();
		}

		private void RegisterEventHandlers()
		{
			_movementAction = _playerInput.currentActionMap.FindAction("Movement");
			_aimAction = _playerInput.currentActionMap.FindAction("Aim");
			_interactAction = _playerInput.currentActionMap.FindAction("Interact");

			_interactAction.started += OnInteractInputStarted;
		}

		private void OnInteractInputStarted(InputAction.CallbackContext context)
			=> OnInteract?.Invoke();

		private void UpdateMovementInput()
		{
			_currentMovementInput = _movementAction.ReadValue<Vector2>();

			if (_currentMovementInput == _lastMovementInput)
				return;

			_lastAimInput = _currentMovementInput;
			OnMovementInputChanged?.Invoke(_currentMovementInput.normalized * Time.fixedDeltaTime);
		}

		private void UpdateAimInput()
		{
			_currentAimInput = _aimAction.ReadValue<Vector2>();

			if (_currentAimInput == _lastAimInput)
				return;

			_currentAimInput = _lastAimInput;
			OnAimInputChanged?.Invoke(_currentAimInput.normalized * Time.fixedDeltaTime);
		}
	}
}