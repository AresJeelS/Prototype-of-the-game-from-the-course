using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _playerTransform;
    public float Speed;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        _rb = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        _rb.velocity = toPlayer * Speed;
    }

}

