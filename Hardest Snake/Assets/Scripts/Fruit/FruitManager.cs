using UnityEngine;

public class FruitManager : MonoBehaviour {

	public GameObject fruitPrefab;

	private Vector3 initialFruit;
	private GameObject[] actualFruits;
	private float fruitCount;

	void Start () {
		initialFruit = new Vector3 (Random.Range (-4.5f,4.5f),Random.Range (-4.5f,4.5f), 0f);
		Instantiate (fruitPrefab, initialFruit, Quaternion.identity);
	}

	void Update () {
		fruitCount = GameObject.FindGameObjectsWithTag ("Fruit").Length;
		actualFruits = GameObject.FindGameObjectsWithTag ("Fruit");

		if (fruitCount == 0) {
			CreateNewFruit ();
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			for (int i = 0; i < fruitCount; i++) {
				Destroy (actualFruits[i]);
			}
		}
	}

	void CreateNewFruit() {
		Vector3 newPosition = new Vector3 (Random.Range (-4.5f,4.5f),Random.Range (-4.5f,4.5f), 0f);
		Instantiate (fruitPrefab, newPosition, Quaternion.identity);
	}
}
