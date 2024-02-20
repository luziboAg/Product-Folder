using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFloor : MonoBehaviour
{
    public float destroyDelay = 0.001f; // Time delay before the platform is destroyed

    private bool playerLanded = false;

    private void Update()
    {
        // Nothing to do in Update since we're using OnCollisionEnter2D and a coroutine
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player has landed on the platform
        if (other.gameObject.CompareTag("Player"))
        {
            if (!playerLanded)
            {
                playerLanded = true;
                // Start the coroutine to destroy the platform after the delay
                StartCoroutine(DestroyPlatformAfterDelay());
            }
        }
    }
    IEnumerator DestroyPlatformAfterDelay()
    {
        // Wait for the specified delay before destroying the platform
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the platform
        Destroy(gameObject);
    }
}
