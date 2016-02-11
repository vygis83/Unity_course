using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock ball in position on the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				print ("Mouse Clicked, launching ball");
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
		//rigidbody2D.velocity += tweak;

		if (hasStarted) {
			this.GetComponent<Rigidbody2D> ().velocity += tweak;
			print (tweak);
			if (collision.gameObject.tag != "Breakable") {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
