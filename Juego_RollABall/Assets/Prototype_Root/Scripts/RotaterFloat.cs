using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterFloat : MonoBehaviour
{
    public float rotationy;
    public float rotationx;
    public float rotationz;
    public float speed;
    Quaternion rotacion;

    void Start()
    {
        rotacion = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotacion * Quaternion.Euler(rotationx * Mathf.Sin(Time.time * speed), rotationy * Mathf.Sin(Time.time * speed), rotationz * Mathf.Sin(Time.time * speed));
    }
}
