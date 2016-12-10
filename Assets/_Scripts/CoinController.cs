using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {


	public AudioSource CoinSound;

	private WaitForSeconds waitTime = new WaitForSeconds(0.15f);

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (PlayCoinSound()); // invoke coroutine
		}
	}

	// Coroutine
	IEnumerator PlayCoinSound() {
		this.CoinSound.Play ();
		yield return this.waitTime;
		this.gameObject.SetActive (false);
	}

	void Update() {
		this.gameObject.transform.Rotate (Vector3.forward * Time.deltaTime * 360);
	}
}
