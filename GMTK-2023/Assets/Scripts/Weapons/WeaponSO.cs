using UnityEngine;

namespace Runtime.Weapons
{
    //[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons", order = 50)]
    public abstract class WeaponSO : ScriptableObject
    {
        public float Damage;
        public float Cooldown;
        public abstract void Shoot();
    }
}
