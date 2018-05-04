using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip ping;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void Ping()
    {
        source.PlayOneShot(ping);
    }
}
