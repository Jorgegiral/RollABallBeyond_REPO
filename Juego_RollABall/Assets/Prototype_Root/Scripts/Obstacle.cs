using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float raiseZ;
    public float speed;
    Vector3 posicion;

    private void Start()
    {
        posicion = transform.localPosition;
    }
    void Update()
    {
        transform.position = new Vector3(posicion.x, posicion.y, posicion.z + raiseZ * Mathf.Sin(Time.time * speed));
    }
}
