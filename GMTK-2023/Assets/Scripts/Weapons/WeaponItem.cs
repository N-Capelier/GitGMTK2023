using UnityEngine;

namespace Runtime.Weapons
{
    public class WeaponItem : MonoBehaviour
    {
        WeaponSO Weapon;

        [SerializeField]
        private MeshRenderer _meshRenderer = null;

        public void Initialize(WeaponSO weaponSO)
        {
            Weapon = weaponSO;
            _meshRenderer.material.SetTexture("_Texture", weaponSO.Display.texture);
        }

        public WeaponSO GetWeapon()
        {
            return Instantiate(Weapon);
        }
    }
}