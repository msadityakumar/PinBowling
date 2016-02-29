using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioSource audioSource;

	private Rigidbody ballRigidBody;
	public bool IsInPlay = false;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		ballRigidBody = this.GetComponent<Rigidbody> ();
		audioSource = this.GetComponent<AudioSource> ();
		startPosition = this.transform.localPosition;

	}
	
	public void LaunchBall (Vector3 velocity)
	{
		IsInPlay = true;
		audioSource.Play ();
		ballRigidBody.isKinematic = false;
		ballRigidBody.velocity = velocity;
		ballRigidBody.AddTorque (Vector3.right*10*velocity.magnitude);

	}

	public void Reset()
	{
		//resset the ball position
		this.transform.position = startPosition;
		IsInPlay = false;
		ballRigidBody.isKinematic = true;
		ballRigidBody.velocity = Vector3.zero;
		ballRigidBody.angularVelocity = Vector3.zero;
		ballRigidBody.angularDrag = 0.0f;
	}
}
