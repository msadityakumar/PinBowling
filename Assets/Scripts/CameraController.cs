using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Ball ball;
	//Vector3 CameraOffset;
	// Use this for initialization
	void Start () {
		//CameraOffset = new Vector3 (0,25,30);
	
	}
	
	// Update is called once per frame
	void Update () {
	//	float zOffset = ball.transform.position.z
		if(ball.transform.position.z < 1829.0f)
		{
			this.transform.position = new Vector3 (0,50,ball.transform.position.z-100);

		}
	}
}
