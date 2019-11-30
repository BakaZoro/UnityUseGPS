using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour {

	public static GPS Instance { set; get; }
	public float latitude;
	public float longitude;

	private void Start(){

		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationService ());
	}

	private IEnumerator StartLocationService(){

		if (!Input.location.isEnabledByUser) {

			Debug.Log ("Location Not Enabled");
			yield break;
		}

		Input.location.Start();
		int maxWait = 15;

		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;

		}

		if (maxWait == 0) {
			Debug.Log ("GPS Timed-Out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Location Not Found");
			yield break;
		}

		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;

		yield break;
	}

}
