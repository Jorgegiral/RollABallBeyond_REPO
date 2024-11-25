using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripsound : MonoBehaviour
{
    private AudioSource Audio;

    // Update is called once per frame
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Audio.Play();
        }
    }
}
