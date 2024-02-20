using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float fallDelay = 1.5f; // Time delay before the object falls
    public LayerMask playerLayer; // Set this to the layer where the player is placed

    private bool isPlayerUnderneath = false;
    private bool hasFallen = false;
    private Rigidbody2D rb;
    private Vector2 originalPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.position;

        // Disable Rigidbody's gravity initially
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (isPlayerUnderneath && !hasFallen)
        {
            // Start a timer to delay the falling behavior
            fallDelay -= Time.deltaTime;
            if (fallDelay <= 0f)
            {
                Fall();
            }
        }
    }

    private void Fall()
    {
        // Enable Rigidbody's gravity to make the object fall
        rb.gravityScale = fallSpeed;
        hasFallen = true;
    }

    private void FixedUpdate()
    {
        // Check if the player is underneath the object using raycasting
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            isPlayerUnderneath = true;
        }
        else
        {
            isPlayerUnderneath = false;
        }
    }
}