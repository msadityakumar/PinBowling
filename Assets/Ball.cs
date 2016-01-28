using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public AudioSource audioSource;

	// Use this for initialization
	void Start () {
		Rigidbody rigidBody = this.GetComponent<Rigidbody> ();
		rigidBody.velocity = new Vector3 (0,0,500);
		audioSource = this.GetComponent<AudioSource> ();
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
