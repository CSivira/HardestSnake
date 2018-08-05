using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

	public float _speed;
	public float frameRate;
	public float rotationSensitivity;
	public List<Transform> tail = new List<Transform>();
	public List<GameObject> points = new List<GameObject>();
	public GameObject tailPrefab;
	public GameObject pointPrefab;
	public GameObject fruitManager;

	private float orientation;
	private Transform spawn;
	private float speed;
	private int snakeZise;
	private float rotation;
	private int pointIndex;
	private int tailIndex;

	void Start() {
		InvokeRepeating("SetRoad",0f,frameRate);
		speed = _speed;
		spawn = transform.GetChild (1);
	}
		
	void FixedUpdate () {
		Rotation ();
		if (GameManager.GameState.menu == GameManager.gameState || GameManager.GameState.dead == GameManager.gameState) {
			_speed = 0f;
		} else {
			_speed = speed;
		}

		if (transform.position.x > 4.7f || transform.position.x < -4.7f || transform.position.y > 4.7f || transform.position.y < -4.7f) {
			GameManager.gameState = GameManager.GameState.dead;
		}

		if (Input.GetKey (KeyCode.M)) {
			orientation = 1f;
		}

		if (Input.GetKey (KeyCode.Z)) {
			orientation = -1f;
		}

		if (!Input.GetKey (KeyCode.Z) && !Input.GetKey (KeyCode.M)){
			orientation = 0f;
		}

		if (points.Count > tail.Count) {
			DestroyRoad ();
		}
	}

	void Rotation(){

		if (orientation == 1f) {
			rotation = -1f * rotationSensitivity;
		}

		if (orientation == -1f) {
			rotation = 1f * rotationSensitivity;
		}

		transform.rotation = Quaternion.Euler(0f,0f,rotation) * transform.rotation ;
		transform.position = Vector3.MoveTowards(transform.position,transform.GetChild(0).transform.position,_speed * Time.deltaTime);
	}

	void SetRoad() {
		if (tail.Count != 0) {
			GameObject newPoint = (GameObject)Instantiate (pointPrefab,spawn.position,transform.rotation);
			points.Add (newPoint);
		}
	}

	void DestroyRoad() {
		Destroy (points[0]);
		points.Remove (points[0]);
	}

	void AddBody() {
		GameObject newTail = (GameObject)Instantiate (tailPrefab, spawn.position, Quaternion.identity);
		tail.Add (newTail.transform);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Block"){
			GameManager.gameState = GameManager.GameState.dead;

		}

		if (col.gameObject.tag == "Fruit"){
			AddBody ();
			fruitManager.SendMessage("ChangePosition");
			GameManager.points++;
		}
	}
}