using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class SoundPlayer : MonoBehaviour {

	public float sfxVolume = 1f;
	public float musicVolume = 1f;
	
	void Start () {
		MessageKit<PlayerEvents>.addObserver(MsgType.PlayerAction, PlayPlayerSFX);
	}

	void PlayPlayerSFX (PlayerEvents action) {
		audio.PlayOneShot(Resources.Load<AudioClip>(action.ToString()), sfxVolume);
	}
}
