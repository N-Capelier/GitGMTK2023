using UnityEngine;

namespace Runtime.Weapons
{
    //[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons", order = 50)]
    public abstract class WeaponSO : ScriptableObject
    {
        public int Damages;
        public float Cooldown;
        public float MoveSpeed;
        public string CastSound;
        public int Amunition;
        public Sprite Display;

        public abstract void Cast(Vector3 origin, Vector2 direction);
    }
}