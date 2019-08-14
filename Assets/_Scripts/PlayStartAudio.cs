using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStartAudio : MonoBehaviour
{
    public AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayMySound()
    {
        audio.Play();
    }
}
