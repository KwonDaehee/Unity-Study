using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class GameObject : MonoBehaviour
{
    private float _speed = 10f;
    private float _size = 0.9f;
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move(GetInputDirection());
    }

    private void Move(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _speed);

        // Get the camera's boundaries
        Camera cam = Camera.main;
        if (cam != null)
        {
            Vector3 screenBottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            Vector3 screenTopRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));

            // Clamp the player's position to the camera's boundaries
            Vector3 playerPosition = transform.position;
            playerPosition.x = Mathf.Clamp(playerPosition.x, screenBottomLeft.x, screenTopRight.x);
            transform.position = playerPosition;
        }
        else
        {
            Debug.LogError("No main camera found!");
        }
    }

    private Vector2 GetInputDirection()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector2(horizontal, vertical).normalized;
    }