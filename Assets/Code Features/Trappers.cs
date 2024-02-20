using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trappers : MonoBehaviour
{
    public float fallDelay = 0.0001f; // Time delay before the platform falls
    public LayerMask playerLayer; // Set this to the layer where the player is placed

    private bool isPlayerUnderneath = false;
    private float originalYPosition;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.Log("No Rigidbody component found on GameObject: " + gameObject.name);
        }

        originalYPosition = rb.position.y;
    }

    private void Update()
    {
        if (isPlayerUnderneath)
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
        // Enable Rigidbody's gravity to make the platform fall
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        // Check if the player is underneath the platform using raycasting
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                isPlayerUnderneath = true;
            }
            else
            {
                isPlayerUnderneath = false;
                fallDelay = 0.0001f; // Reset the fall delay timer
            }
        }
    } 
}