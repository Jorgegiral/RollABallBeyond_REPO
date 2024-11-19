using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class prueba2jorge : MonoBehaviour
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

        if (transform.position.x <= -30f)
        {
            transform.position = new Vector3(30f, posicion.y, posicion.z);
        }
    }
}
