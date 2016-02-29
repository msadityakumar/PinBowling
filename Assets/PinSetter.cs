using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	// Use this for initialization
	private GameObject []PinsArray;
	public Text StandingPinText;
	bool isBallEntered = false;
	private int lastStandingCount = -1;
	int pinCount ;
	float lastChangeTime = 0.0f;
	Ball ball;
	void Start () {
		PinsArray = GameObject.FindGameObjectsWithTag ("pin");
		pinCount = 0;
		ball = GameObject.Find ("Ball").GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isBallEntered) {
		//the ball has entered the collider
			checkStanding();
		}
	}

	void checkStanding()
	{
		int currentStandingCount = CountStanding ();
		if (currentStandingCount != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStandingCount;
		}

		float settleTime = 3.0f;

		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled ();	
		}
	}

	void PinsHaveSettled()
	{
		Debug.Log ("pinsHaveSettled");
		StandingPinText.color = Color.green;
		lastStandingCount = -1;
		isBallEntered = false;
		ball.Reset ();

	}

	int CountStanding()
	{
		pinCount = 0;
		foreach (GameObject pin in PinsArray) 
		{
			if (pin) {
				Pin pinComponent = pin.GetComponent<Pin> ();
				bool pinStanding =	pinComponent.IsPinStanding ();
				if (pinStanding) {
					pinCount++;
				}
			}
		}
		StandingPinText.text = pinCount.ToString();
		return pinCount;
	
	}
	void  OnTriggerEnter(Collider colliderObj)
	{
		if (colliderObj.tag == "ball") {
			isBallEntered = true;
			StandingPinText.color = Color.red;
		
		}

	}

	void OnTriggerExit(Collider colliderObj)
	{
		Debug.Log ("trigger exit");
		//if the collider is of type pin then destroy the object
		if (colliderObj.tag != "ball") {
		
			Destroy(colliderObj.gameObject);
		}
			
	}
		
}
