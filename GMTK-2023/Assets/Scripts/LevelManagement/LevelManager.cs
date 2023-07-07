using UnityEngine;

namespace Runtime.LevelManagement
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header("Level Settings")]
        public Transform HumanSpawnPoint = null;
        public Transform BossSpawnPoint = null;
    }
}
