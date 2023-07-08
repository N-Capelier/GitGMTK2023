using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime
{
    public class GrassBehavior : MonoBehaviour
    {

        private bool isIgnited = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == "Fire" && isIgnited == false)
            {
                Ignite();
            }
        }

        void Ignite()
        {
            isIgnited = true;
            //Change anim + create start fire FX + SFX
            //Create a AOE as child that can burn the player
            //Wait 5 seconds
            //FX + SFX + Destroy(gameobject)
        }
    }
}
