using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Animation
{
    [System.Serializable]
    public struct SpriteAnimation
    {
		public string Name;
		public Sprite[] Sprites;
        [Tooltip("Frames per second")]
		public float FrameRate;
	}

    [CreateAssetMenu(fileName = "SpriteAnimatorController", menuName = "ScriptableObjects/SpriteAnimatorController", order = 50)]
    public class SpriteAnimatorController : ScriptableObject
    {
        public List<SpriteAnimation> Animations;
    }
}
