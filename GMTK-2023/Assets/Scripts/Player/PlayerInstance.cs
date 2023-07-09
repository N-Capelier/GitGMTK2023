using Runtime.Entities;
using UnityEngine;

namespace Runtime.Player
{
    public class PlayerInstance : MonoBehaviour
    {
        private Entity _entity = null;
        public Entity CurrentEntity => _entity;

        [Header("References")]
        [SerializeField]
        Human _humanPrefab = null;
        [SerializeField]
        Boss _bossPrefab = null;

        [SerializeField]
        private PlayerInputManager _inputManager = null;
        public PlayerInputManager InputManager => _inputManager;

        [HideInInspector]
        public int HumanHealthPoints = default;

        //[ContextMenu("Create Human Entity")]
        public void CreateHumanEntity(Transform spawnPoint, bool useRegisteredHealthPoints = false)
        {
            if (_entity != null)
                DestroyEntity();

            _entity = Instantiate(_humanPrefab, spawnPoint.position, spawnPoint.rotation, transform);
            _entity.Initialize(this, useRegisteredHealthPoints);
        }

        //[ContextMenu("Create Boss Entity")]
        public void CreateBossEntity(Transform spawnPoint)
        {
			if (_entity != null)
				DestroyEntity();

			_entity = Instantiate(_bossPrefab, spawnPoint.position, spawnPoint.rotation, transform);
			_entity.Initialize(this);
		}

        public void DestroyEntity()
        {
            _entity.Kill();
            Destroy(_entity.gameObject);
        }
    }
}