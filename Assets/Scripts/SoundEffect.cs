using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour {

    public static AudioClip peerTalkSound, clockSound, ghostSound;
    static AudioSource audioSrc;



	// Use this for initialization
	void Start () {
        peerTalkSound = Resources.Load<AudioClip>("PeerTalk");
        clockSound = Resources.Load<AudioClip>("ClockTick");
        ghostSound = Resources.Load<AudioClip>("Ghostly");

        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "PeerTalk":
                audioSrc.PlayOneShot(peerTalkSound);
                break;

            case "ClockTick":
                audioSrc.PlayOneShot(clockSound);
                break;

            case "Ghostly":
                audioSrc.PlayOneShot(ghostSound);
                break;
        }
    }

}
