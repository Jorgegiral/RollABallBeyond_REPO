using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public float raiseY;
    public float speed;
    Vector3 posicion;

    private void Start()
    {
        posicion = transform.localPosition;
    }
    void Update()
    {
        transform.position = new Vector3(posicion.x, posicion.y + raiseY * Mathf.Sin(Time.time * speed), posicion.z);
    }
}
