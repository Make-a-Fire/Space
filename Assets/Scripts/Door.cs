using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Collider component
    private BoxCollider2D colliderComponent;

    // Disable time in seconds
    public float disableTime = 2f;

    private void Start()
    {
        // Get the collider component
        colliderComponent = GetComponent<BoxCollider2D>();

        // Disable the collider for disableTime seconds
        colliderComponent.enabled = false;
        Invoke("EnableCollider", disableTime);
    }

    private void EnableCollider()
    {
        // Enable the collider
        colliderComponent.enabled = true;
    }
}
