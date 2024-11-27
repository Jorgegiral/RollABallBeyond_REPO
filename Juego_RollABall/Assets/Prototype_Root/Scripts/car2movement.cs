using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car2movement : MonoBehaviour
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

    if (transform.position.x <= -350f)
    {
        transform.position = new Vector3(120f, posicion.y, posicion.z);
    }
}
}
