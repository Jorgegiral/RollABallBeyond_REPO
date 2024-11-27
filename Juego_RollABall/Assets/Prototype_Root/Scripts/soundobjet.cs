using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Soundpickup;

public class soundobjet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproduce el sonido en el jugador
            other.GetComponent<Soundpickup>().PlayPickupSound();

            other.gameObject.SetActive(false);
        }
    }
}