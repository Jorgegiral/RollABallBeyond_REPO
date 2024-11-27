using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundpickup : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip pickupSound;   
    public AudioClip jumpSound;

    public void PlayPickupSound()
    {
        audioSource.PlayOneShot(pickupSound);
    }
    public void PlayjumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
}