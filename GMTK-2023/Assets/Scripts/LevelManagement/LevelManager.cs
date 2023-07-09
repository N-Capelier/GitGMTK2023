using UnityEngine;

namespace Runtime.LevelManagement
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header("Level Settings")]
        public Transform StartGamePlayer1SpawnPoint = null;
        public Transform StartGamePlayer2SpawnPoint = null;
		[Space]
        public Transform HumanSpawnPoint = null;
        public Transform BossSpawnPoint = null;

		private void Awake()
		{
            CreateSingleton();
		}
	}
}
