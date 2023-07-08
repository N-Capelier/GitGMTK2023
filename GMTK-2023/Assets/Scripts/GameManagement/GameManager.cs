using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.GameManagement
{
	public class GameManager : Singleton<GameManager>
	{
		[Header("References")]
		[SerializeField]
		private UnityEngine.InputSystem.PlayerInputManager _playerInputManager = null;

		private Camera _mainCamera = null;
		public Camera MainCamera => GetMainCamera();


		public bool IsLobbyReady = false;

		private void Start()
		{
			_playerInputManager.onPlayerJoined += OnPlayerJoined;
		}

		private void OnPlayerJoined(PlayerInput obj)
		{
			if (_playerInputManager.playerCount != 2)
				return;

			IsLobbyReady = true;
			StartGame();
		}

		public void StartGame()
		{

		}

		public void StartRound()
		{

		}

		private Camera GetMainCamera()
		{
			if (_mainCamera == null)
				_mainCamera = Camera.main;

			return _mainCamera;
		}
	}
}