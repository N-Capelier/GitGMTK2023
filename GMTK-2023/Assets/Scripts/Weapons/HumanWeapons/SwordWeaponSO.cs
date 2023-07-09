using UnityEngine;

namespace Runtime.Weapons
{
	[CreateAssetMenu(fileName = "Sword", menuName = "ScriptableObjects/Weapons/Human/Sword", order = 50)]
	public class SwordWeaponSO : WeaponSO
	{
		[SerializeField]
		private SwordBullet _swordBulletPrefab = null;

		public override void Cast(Vector3 origin, Vector2 direction)
		{
			Instantiate(_swordBulletPrefab, origin, Quaternion.identity);
		}
	}
}
