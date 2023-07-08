using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Audio
{
    [System.Serializable]
    public struct AudioData
    {
		public string Name;
		public AudioClip Clip;
	}

    [CreateAssetMenu(fileName = "AudioList", menuName = "ScriptableObjects/AudioList", order = 50)]
    public class AudioList : ScriptableObject
    {
        public List<AudioData> AudioData;
    }
}
