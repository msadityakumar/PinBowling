using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class TouchDrag : MonoBehaviour {

	 private Ball ball;
	private Vector3 startPosition;
	private Vector3 endPosition;
	public float touchDownTime ;
	public float touchUpTime;
	float xMin,xMax;


	// Use this for initialization
	void Start () {
		ball =this.GetComponent<Ball>();
		xMin = -52.5f;
		xMax = 52.5f;
	}
	
 	public void TouchDown()
	{
		//drag start
		Debug.Log ("dragStarted");

		startPosition = Input.mousePosition;
		touchDownTime = Time.time;
	}

	public void TouchEnded()
	{
		touchUpTime = Time.time;
		float timeDiff = touchUpTime - touchDownTime;
		Debug.Log ("dragEnded");
		endPosition = Input.mousePosition;
	
		float xVelocity = (endPosition.x - startPosition.x) / timeDiff;
		float zVelocity = (endPosition.y - startPosition.y) / timeDiff;

		Vector3 velocity = new Vector3 (xVelocity,0.0f/*direction.y*speed*/,zVelocity);

		ball.LaunchBall (velocity);
	

		//drag end
	//	ball.LaunchBall()
	}

	public void nudgeBall(float distance)
	{
		Rigidbody ballRigidBody = this.GetComponent<Rigidbody>();
		if (ballRigidBody.isKinematic) {
			float xDistance = this.transform.position.x + distance;
			float xPosition = Mathf.Clamp (xDistance, xMin, xMax);
			Vector3 ballVector = new Vector3 (xPosition, this.transform.position.y, this.transform.position.z);
			this.transform.position = ballVector;
		}

	}
}
