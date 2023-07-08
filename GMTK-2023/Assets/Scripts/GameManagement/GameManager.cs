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

		private PlayerInstance _player1 = null;
		private PlayerInstance _player2 = null;

		public bool IsLobbyReady = false;

		private void Start()
		{
			_playerInputManager.onPlayerJoined += OnPlayerJoined;
		}

		private void OnPlayerJoined(PlayerInput obj)
		{
			if(_player1 == null)
			{
				_player1 = obj.GetComponent<PlayerInstance>();
			}
			else
			{
				_player2 = obj.GetComponent<PlayerInstance>();
			}

			if (_playerInputManager.playerCount != 2)
				return;

			IsLobbyReady = true;
			StartGame();
		}

		public void StartGame()
		{
			_player1.CreateHumanEntity();
			_player2.CreateHumanEntity();
		}

		private Camera GetMainCamera()
		{
			if (_mainCamera == null)
				_mainCamera = Camera.main;

			return _mainCamera;
		}
	}
}