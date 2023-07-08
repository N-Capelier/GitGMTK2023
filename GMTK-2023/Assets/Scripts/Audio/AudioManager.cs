using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Audio
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Params")]
        [SerializeField]
        private AudioList _audioList = null;

        [Header("References")]
        [SerializeField]
        private AudioPlayer _audioPlayerPrefab = null;

        private Dictionary<string, AudioData> _audioDictionary = null;

		private void Start()
		{
			_audioDictionary = new Dictionary<string, AudioData>();
            foreach(AudioData audioData in _audioList.AudioData)
            {
                if(_audioDictionary.ContainsKey(audioData.Name))
                {
					Debug.LogError($"AudioManager: AudioData with name {audioData.Name} already exists!");
					continue;
				}
				_audioDictionary.Add(audioData.Name, audioData);
			}
		}

		public void PlayAudio(string clipName, bool loop = false)
        {
            if(_audioDictionary.TryGetValue(clipName, out AudioData audioData))
                PlayAudio(audioData.Clip, loop);
            else
                Debug.LogError($"AudioManager: AudioData with name {clipName} not found!");
        }

        private void PlayAudio(AudioClip clip, bool loop)
        {
			AudioPlayer audioPlayer = Instantiate(_audioPlayerPrefab);
			audioPlayer.Init(clip, loop);
		}
    }
}
