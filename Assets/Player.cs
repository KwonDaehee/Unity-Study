using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    float power = 10.0f;

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.up * power);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.down * power);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * power);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * power);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}