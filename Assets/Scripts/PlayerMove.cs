using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public Transform colliderTransform;

    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxSpeed;

    private int _jumpFrameCounter;

    private bool _isJump;
    public bool Grounded;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Grounded = false;
            _isJump = true;

        }

    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (Grounded == false)
        {
            speedMultiplier = 0.2f;
            if (_rb.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0f;
            }
            if (_rb.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0f;
            }
        }

        _rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded)
        {
            _rb.AddForce(-_rb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15f);

        }

        if (_isJump)
        {
            Jump();        
        }
        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            _rb.freezeRotation = false;
            _rb.AddRelativeTorque(0f, 0f, 7f, ForceMode.VelocityChange);
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                Grounded = true;
                _rb.freezeRotation = true;
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
    public void Jump()
    {
        _rb.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
        _isJump = false;
    }
}
