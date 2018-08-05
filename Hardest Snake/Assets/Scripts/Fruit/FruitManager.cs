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

	void ChangePosition() {
		fruitCount = GameObject.FindGameObjectsWithTag ("Fruit").Length;
		actualFruits = GameObject.FindGameObjectsWithTag ("Fruit");
		for (int i = 0; i < fruitCount; i++) {
			Destroy (actualFruits[i]);
		}
		CreateNewFruit ();
	}

	void CreateNewFruit() {
		Vector3 newPosition = new Vector3 (Random.Range (-4.5f,4.5f),Random.Range (-4.5f,4.5f), 0f);
		Instantiate (fruitPrefab, newPosition, Quaternion.identity);
	}
}
