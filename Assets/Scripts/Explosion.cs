using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;
    bool animationFinished = false;  

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && animationFinished)
        {
            Destroy(gameObject);
        }
    }

    public void PlayedExplosion() // called by animation Event
    {
        animationFinished = true;
        GetComponent<SpriteRenderer>().enabled = false; 
    }
}
