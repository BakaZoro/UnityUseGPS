using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPS: MonoBehaviour {

	public Text coord;

	private void Update(){
	
		coord.text = "Latitude :" + GPS.Instance.latitude.ToString () + "   Longitude :" + GPS.Instance.longitude.ToString ();
	}
}
