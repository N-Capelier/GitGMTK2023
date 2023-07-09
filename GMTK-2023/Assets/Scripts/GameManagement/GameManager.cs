using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Entities;
using Runtime.LevelManagement;
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

		[HideInInspector]
		public bool IsLobbyReady = false;

		public event Action<int> OnPlayerJoinedWithInput;

		private void Start()
		{
			_playerInputManager.onPlayerJoined += OnPlayerJoined;
		}

		private void OnPlayerJoined(PlayerInput obj)
		{
			if(_player1 == null)
			{
				OnPlayerJoinedWithInput?.Invoke(0);
				_player1 = obj.GetComponent<PlayerInstance>();
			}
			else
			{
				OnPlayerJoinedWithInput?.Invoke(1);
				_player2 = obj.GetComponent<PlayerInstance>();
			}

			IsLobbyReady = true;
		}

		public void StartGame()
		{
			_player1.CreateHumanEntity(LevelManager.Instance.StartGamePlayer1SpawnPoint);
			_player2.CreateHumanEntity(LevelManager.Instance.StartGamePlayer2SpawnPoint);

			//=> Instantiate boss
		}

		public void StartRound(PlayerInstance human, PlayerInstance boss)
		{
			human.CreateHumanEntity(LevelManager.Instance.HumanSpawnPoint);
			boss.CreateBossEntity(LevelManager.Instance.BossSpawnPoint);
		}

		public void OnHumanDeath()
		{
			PlayerInstance winner;
			if (_player1.CurrentEntity is Boss)
				winner = _player1;
			else
				winner = _player2;

			//=> Win
		}

		public void OnBossDeath()
		{
			PlayerInstance deadPlayer;
			if(_player1.CurrentEntity is Boss)
				deadPlayer = _player1;
			else
				deadPlayer = _player2;

			PlayerInstance human = null;
			PlayerInstance boss = null;

			foreach(PlayerInstance player in new PlayerInstance[] { _player1, _player2 })
			{
				if(player != deadPlayer)
				{
					player.HumanHealthPoints = player.CurrentEntity.HealthBar.CurrentHealthPoints;
					boss = player;
				}
				else
				{
					human = player;
				}
				player.DestroyEntity();
			}

			StartRound(human, boss);
		}

		private Camera GetMainCamera()
		{
			if (_mainCamera == null)
				_mainCamera = Camera.main;

			return _mainCamera;
		}
	}
}