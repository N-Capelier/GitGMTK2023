using UnityEngine;

namespace Runtime.Weapons
{
    //[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons", order = 50)]
    public abstract class WeaponSO : ScriptableObject
    {
        public float Damages;
        public float Cooldown;
        public abstract void Shoot(Vector3 origin, Vector2 direction);
    }
}