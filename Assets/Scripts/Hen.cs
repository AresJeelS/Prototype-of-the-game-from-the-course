using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _playerTransform;
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized; // Векторная величина 
        Vector3 force = _rb.mass * (toPlayer * Speed - _rb.velocity) / TimeToReachSpeed;

        _rb.AddForce(force);
    }
}
