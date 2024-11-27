using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public float speed;
    Vector3 posicion;

    private void Start()
    {
        posicion = transform.localPosition;
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x >= 120f)
        {
            transform.position = new Vector3(-350f, posicion.y, posicion.z);
        }
    }
}

