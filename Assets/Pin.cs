using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {


	private bool IsStanding;
	public float thresholdAngle;
	// Use this for initialization
	void Start () {
		IsStanding = true;
		checkPinAngle ();
	}

	void Update()
	{

		checkPinAngle ();
	}

	void checkPinAngle()
	{
		float xAngle = Mathf.Abs (this.transform.eulerAngles.x );
		float zAngle = Mathf.Abs (this.transform.eulerAngles.z);
		if (xAngle > thresholdAngle || zAngle > thresholdAngle)
		{
			IsStanding = false;
			return;
		}
		IsStanding = true;
	}


	public bool IsPinStanding()
	{
		return IsStanding;

	}

}
