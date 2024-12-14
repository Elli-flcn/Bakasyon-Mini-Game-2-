using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledorEnabled : MonoBehaviour
{
    // Reference to the image GameObject (set via the Inspector)
    [SerializeField] private GameObject image;

    public void Trigger()
    {
        // Toggle the active state of the image GameObject
        if (image.activeInHierarchy)
        {
            image.SetActive(false); // If it's deactivate, activate it
        }
        else{
            image.SetActive(true); // If it's deactivate, activate it
        }
    }

    private void Awake()
    {
        // Ensure the image GameObject is inactive at startup
        if (image != null)
        {
            image.SetActive(false);
        }
    }
}
