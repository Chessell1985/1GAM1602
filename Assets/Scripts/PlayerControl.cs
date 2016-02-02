using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public bool facingRight = true;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {

		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		float h = Input.GetAxis ("Horizontal");

		if (h == 0) {
		
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
		
		}

		if (h * rb2d.velocity.x < maxSpeed) {

			rb2d.AddForce (Vector2.right * h * moveForce);

		}

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {

			rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		}

	}
}
