using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody _rb;
    private Camera _camera;

    public Vector3 offset;

    public float smoothSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        _rb.MovePosition(smoothedPosition);
    }
}
