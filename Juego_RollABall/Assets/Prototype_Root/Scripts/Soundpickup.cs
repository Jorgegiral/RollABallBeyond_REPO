using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundpickup : MonoBehaviour
{
        public AudioSource audioSource; // Asigna un AudioSource en el inspector.
        public AudioClip pickupSound;   // Asigna el clip del sonido en el inspector.

        public void PlayPickupSound()
        {
            audioSource.PlayOneShot(pickupSound);
        }
    
}