using UnityEngine;

namespace Runtime.Weapons
{
    public class WeaponItem : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField]
        WeaponSO Weapon;

        public WeaponSO GetWeapon()
        {
            return Instantiate(Weapon);
        }
    }
}