using System.Collections;
using System.Collections.Generic;
using Runtime.Player;
using UnityEngine;
using Runtime.Entities.Components;
using Runtime.HealthSystem;

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
        public HealthBar HealthBar = null;

        public virtual void Initialize(PlayerInstance owner, bool useRegisteredHealthPoints = false)
        {
            Owner = owner;
            Movement.Initialize(this);
            Aim.Initialize(this);
            Interaction.Initialize(this);
        }

        public void Kill()
        {
            Movement.Kill();
            Aim.Kill();
            Interaction.Kill();
        }
    }
}
