using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class StoneBehavior : MonoBehaviour
    {
        private bool isDestroyed = false;
        private float rebuiltCooldown;
        public float cooldownValue;
        private int currentHp;
        public int maxHp;


        private void Awake()
        {
            rebuiltCooldown = cooldownValue;
            currentHp = maxHp;
        }
        private void Update()
        {
            if (currentHp <= 0 && isDestroyed == false)
            {
                DestroyStone();
            }
            else if (isDestroyed == true && rebuiltCooldown > 0)
            {
                rebuiltCooldown -= Time.fixedDeltaTime;
            }
            else if (isDestroyed == true && rebuiltCooldown <= 0)
            {
                RebuildStone();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Projectile")
            {
                DestroyProjectile(collision.gameObject);
            }
        }

        private void DestroyProjectile(GameObject collision)
        {
            currentHp -= 1;
            //Create FX + SFX
            Destroy(collision);
        }

        private void DestroyStone()
        {
            rebuiltCooldown = cooldownValue;
            isDestroyed = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //Change anim to destroyed anim
            //SFX + FX
        }

        private void RebuildStone()
        {
            isDestroyed = false;
            currentHp = maxHp;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            //Change anim to default anim
            //SFX + FX

        }
    }
}
