using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Librería para poder referenciar elementos de User Interface.
using TMPro; //Librería para poder referenciar elementos de Text Mes Pro

public class PlayerInteraction : MonoBehaviour
{

    [Header("UI References")]
    public TMP_Text pointsText; //Ref al texto de Ui que quiero que cambie dinámicamente según los puntos del player
    public TMP_Text lifeText;

    [Header("Scene Management")]
    public SceneChanger sceneManagerScript;
    public int sceneToLoad;

    [Header("Point System Parameters")]
    // Variables para definir los puntos del jugador
    public int currentPoints;
    public int lifePoints;
    public int winPoints = 10;
    public GameObject winGoal;

    [Header("Respawn Parameters")]
    public Transform respawnPoint;
    public float respawnFallLimit;

    private void Update()
    {
        if (currentPoints < 0) { currentPoints = 0; }
        if (transform.position.y <= respawnFallLimit) { Respawn(); }
        if (lifePoints == 0) { LooseCall(); }
        UIUpdate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Joy") || other.gameObject.CompareTag("Sadness") || other.gameObject.CompareTag("Angry") || other.gameObject.CompareTag("Fear") || other.gameObject.CompareTag("Disgust"))
        {
            currentPoints += 1;

            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
        }
        if (currentPoints == winPoints)
        {
            lifePoints++;
            currentPoints = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) { Respawn(); }
    }
    void Respawn()
    {
        currentPoints = 0;
        lifePoints -= 1;
        transform.position = respawnPoint.position;
    }

    void UIUpdate()
    {
        pointsText.text = "Soul: " + currentPoints.ToString() + "/" + winPoints.ToString();
        lifeText.text = "Life: " + lifePoints.ToString();
    }

    void LooseCall()
    {
        //Acciòn del cambio de escena
        sceneManagerScript.SceneLoader(sceneToLoad);

    }
}

