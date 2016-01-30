using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioSource audioSource;

	private Rigidbody ballRigidBody;
	// Use this for initialization
	void Start () {
		ballRigidBody = this.GetComponent<Rigidbody> ();
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	public void LaunchBall (Vector3 velocity)
	{
		audioSource.Play ();
		ballRigidBody.isKinematic = false;
		ballRigidBody.velocity = velocity;
		ballRigidBody.AddTorque (Vector3.right*10*velocity.magnitude);

	}
}
