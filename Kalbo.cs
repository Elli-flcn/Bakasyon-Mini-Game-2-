using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kalbo : MonoBehaviour
{
    Rigidbody2D rb;

	[SerializeField]
	GameObject codePanel, closedSafe, openedSafe;

	public static bool isSafeOpened = false;
    private Vector3 startingPosition;

    private void Awake()
    {
        // Record the starting position
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D> ();
		codePanel.SetActive (false);
		closedSafe.SetActive (true);
		openedSafe.SetActive (false);
    }

    public void ResetState()
    {
        // Reset Kalbo's position
        transform.position = startingPosition;

        // Reactivate Kalbo if it was disabled
        gameObject.SetActive(true);
    }
    	// Update is called once per frame
	void Update () {

		if (isSafeOpened) {
			codePanel.SetActive (false);
			closedSafe.SetActive (false);
			openedSafe.SetActive (true);
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Door") && !isSafeOpened) {
			codePanel.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Door")) {
			codePanel.SetActive (false);
		}
	}
}
