using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudio : MonoBehaviour
{
    public AudioSource deathSound;
    private void OnEnable()
    {
        deathSound.Play();
    }
}
