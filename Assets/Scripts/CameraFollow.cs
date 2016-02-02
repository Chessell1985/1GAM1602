using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float xMargin = 1f;
	public float xSmooth = 1f;
	public float xMin = -13.5f;
	public float xMax = 13.5f;

	public GameObject ground;
	public GameObject player;

	private Transform playerTransform;

	// Use this for initialization
	void Awake () {
	
		playerTransform = player.transform;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		TrackPlayer ();

	}

	bool CheckXMargin () {
		return Mathf.Abs(transform.position.x - playerTransform.position.x) > xMargin;
	}

	void TrackPlayer () {

		float targetX = transform.position.x;

		// If the player has moved beyond the x margin...
		if (CheckXMargin ()) {

			targetX = Mathf.Lerp(transform.position.x, playerTransform.position.x, xSmooth * Time.deltaTime);

		}

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, xMin, xMax);

		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);

	}
}
