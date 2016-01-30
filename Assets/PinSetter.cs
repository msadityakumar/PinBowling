using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	// Use this for initialization
	private GameObject []PinsArray;
	public Text StandingPinText;
	bool isBallEntered = false;
	private int standingCount = -1;
	int pinCount ;
	void Start () {
		PinsArray = GameObject.FindGameObjectsWithTag ("pin");
		pinCount = 0;
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
		pinCount = 0;
		foreach (GameObject pin in PinsArray) 
		{
			
			Pin pinComponent = pin.GetComponent<Pin>();
			bool pinStanding =	pinComponent.IsPinStanding();
			if(pinStanding)
			{
				pinCount++;
			}
		}
		StandingPinText.text = pinCount.ToString();
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

			Destroy(colliderObj.gameObject);


	}
}
