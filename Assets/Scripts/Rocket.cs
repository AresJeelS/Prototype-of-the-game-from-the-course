using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }


    void Update()
    {
        transform.position += Speed * Time.deltaTime * transform.forward;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }
}
