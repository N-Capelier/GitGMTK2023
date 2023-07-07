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
        [SerializeField]
        private EntityMovement _movement = null;

        public virtual void Initialize(PlayerInstance owner)
        {
            Owner = owner;
            _movement.Initialize(this);
        }
    }
}
