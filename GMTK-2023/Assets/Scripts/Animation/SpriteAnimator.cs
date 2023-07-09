using System.Collections;
using UnityEngine;

namespace Runtime.Animation
{
	public class SpriteAnimator : MonoBehaviour
	{
		public SpriteAnimatorController controller = null;
		public bool PlayOnAwake = true;
		public string DefaultAnimation = string.Empty;

		private const string TEXTURE_PROPERTY = "_Texture";

		private Material _material = null;

		private void Awake()
		{
			if (PlayOnAwake && !string.IsNullOrEmpty(DefaultAnimation))
			{
				Play(DefaultAnimation);
			}
		}

		public void Play(string animationName)
		{
			if (controller == null)
			{
				Debug.LogError("SpriteAnimatorController is null");
				return;
			}
			if (string.IsNullOrEmpty(animationName))
			{
				Debug.LogError("Animation name is null or empty");
				return;
			}
			if (_material == null)
			{
				_material = GetComponent<MeshRenderer>().material;
			}
			var animation = controller.Animations.Find(a => a.Name == animationName);
			if (animation.Sprites.Length == 0)
			{
				Debug.LogError($"Animation {animationName} has no sprites");
				return;
			}
			StopAllCoroutines();
			StartCoroutine(PlayAnimation(animation));
		}

		private IEnumerator PlayAnimation(SpriteAnimation animation)
		{
			float frameTime = 1f / animation.FrameRate;
			int frameIndex = 0;
			while (true)
			{
				_material.SetTexture(TEXTURE_PROPERTY, animation.Sprites[frameIndex].texture);
				yield return new WaitForSeconds(frameTime);
				frameIndex++;
				if (frameIndex >= animation.Sprites.Length)
					frameIndex = 0;
			}
		}
	}
}
