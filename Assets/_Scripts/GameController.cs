using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Transform SpawnPoint;
	public GameObject Player; // player prefab
	public GameObject Coin; // coin prefab
	public int MaxCoins = 20;

	private List<GameObject> CoinPool; // reference to the CoinPool List

	// Use this for initialization
	void Start () {
		Instantiate (this.Player);
		this.Player.transform.position = SpawnPoint.position; // spawn the player at the SpawnPoint
		this.CoinPool = new List<GameObject>(); // initialize the CoinPool
		this.BuildCoinPool();
	}
	
	// Update is called once per frame
	void Update () {
		this.PlaceCoins ();
	}

	private void BuildCoinPool() {
		for (int countCount = 0; countCount < this.MaxCoins; countCount++) {
			GameObject coin = (GameObject)Instantiate (this.Coin);
			coin.SetActive (false);
			this.CoinPool.Add (coin);
		}
	}

	private void PlaceCoins() {
		foreach (var coin in CoinPool) {
			if (!coin.activeInHierarchy) { // search the pool for a coin that is not in the scene
				coin.SetActive (true); // place the coin in the scene
				coin.transform.position = new Vector3 (Random.Range (-20f, 20f), 20, Random.Range (-20f, 20f));
			}
		}
	}
}
