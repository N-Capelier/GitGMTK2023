using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Runtime.GameManagement;
using System;
using UnityEngine.UI;

namespace Runtime.UI
{
    public class MainMenuManager : Singleton<MainMenuManager>
    {
        [Header("References")]
		[SerializeField]
		private Canvas _mainMenuCanvas = null;
        [SerializeField]
        private TextMeshProUGUI _player1JoinTMP = null;
        [SerializeField]
        private TextMeshProUGUI _player2JoinTMP = null;
		[SerializeField]
		private TextMeshProUGUI _lobbyStateTMP = null;

		private void Start()
		{
			GameManager.Instance.OnPlayerJoinedWithInput += OnPlayerJoined;
		}

		private void OnPlayerJoined(int playerIndex)
		{
			if(playerIndex == 0)
			{
				_player1JoinTMP.text = "Player 1\nReady!";
			}
			else
			{
				_player2JoinTMP.text = "Player 2\nReady!";
				_lobbyStateTMP.text = "Game will start soon...";
				new CountdownTimer().SetTime(3f, StartGame);
			}
		}

		private void StartGame()
		{
			_mainMenuCanvas.gameObject.SetActive(false);
			GameManager.Instance.StartGame();
		}
	}
}