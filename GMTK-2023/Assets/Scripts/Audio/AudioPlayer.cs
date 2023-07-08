using UnityEngine;

namespace Runtime.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private AudioSource _audioSource = null;

        private CountdownTimer _destroyAwait = new();
        private bool _canBeDestroyed = false;

        public void Init(AudioClip clip, bool loop)
        {
            hideFlags = HideFlags.HideInHierarchy;

            _audioSource.clip = clip;
            _audioSource.loop = loop;
			_audioSource.Play();

            _destroyAwait.SetTime(.2f, () => _canBeDestroyed = true);
        }

		private void Update()
		{
            if(_canBeDestroyed && !_audioSource.isPlaying)
				Destroy(gameObject);
		}
	}
}
