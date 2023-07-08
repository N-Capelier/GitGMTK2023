using System.Collections;
using System.Collections.Generic;
using Runtime.Player;
using UnityEngine;
using Runtime.Entities.Components;

namespace Runtime.Entities
{
    public abstract class Entity : MonoBehaviour
    {
        [HideInInspector]
        public PlayerInstance Owner = null;

        [Header("References")]
        public EntityMovement Movement = null;
        public EntityAim Aim = null;
        public EntityInteraction Interaction = null;

        public virtual void Initialize(PlayerInstance owner)
        {
            Owner = owner;
            Movement.Initialize(this);
        }
    }
}
