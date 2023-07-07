using Runtime.Entities;
using Runtime.LevelManagement;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerInstance : MonoBehaviour
    {
        private Entity _entity = null;

        [Header("References")]
        [SerializeField]
        Human _humanPrefab = null;
        [SerializeField]
        Boss _bossPrefab = null;

        [SerializeField]
        private PlayerInputManager _inputManager = null;
        public PlayerInputManager InputManager => _inputManager;

        [ContextMenu("Create Human Entity")]
        public void CreateHumanEntity()
        {
            if (_entity != null)
                DestroyEntity();

            LevelManager levelManager = LevelManager.Instance;

            _entity = Instantiate(_humanPrefab, levelManager.HumanSpawnPoint.position, levelManager.HumanSpawnPoint.rotation, transform);
            _entity.Initialize(this);
        }

        [ContextMenu("Create Boss Entity")]
        public void CreateBossEntity()
        {
			if (_entity != null)
				DestroyEntity();

			LevelManager levelManager = LevelManager.Instance;

			_entity = Instantiate(_bossPrefab, levelManager.BossSpawnPoint.position, levelManager.BossSpawnPoint.rotation, transform);
			_entity.Initialize(this);
		}

        public void DestroyEntity()
        {
            Destroy(_entity.gameObject);
        }
    }
}