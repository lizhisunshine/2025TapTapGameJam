using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonVoise : MonoBehaviour
{
    private AudioSource AudioSource;
    public AudioClip clip;
    void Start()
    {
        AudioSource = this.GetComponent<AudioSource>();
        this.GetComponent<Button>().onClick.AddListener(PlayMusic);
    }

    public void PlayMusic()
    {
        AudioSource.PlayOneShot(clip);
    }
}
