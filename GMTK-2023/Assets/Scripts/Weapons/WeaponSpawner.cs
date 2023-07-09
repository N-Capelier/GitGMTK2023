using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Weapons
{
    public class WeaponSpawner : Singleton<WeaponSpawner>
    {
        [SerializeField]
        private WeaponItem WeaponItemPrefab = null;

        public List<Transform> SpawnPoints = new();
        public List<WeaponSO> HumanWeapons = new();

        [ContextMenu("SpawnHumanWeapon")]
        public void SpawnHumanWeapon()
        {
            int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
            WeaponItem item = Instantiate(WeaponItemPrefab, SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
            item.Initialize(HumanWeapons[Random.Range(0, HumanWeapons.Count)]);
        }
    }
}
