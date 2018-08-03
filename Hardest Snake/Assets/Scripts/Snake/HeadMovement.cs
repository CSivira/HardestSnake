using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

	public List<Transform> tail = new List<Transform>();

	public GameObject TailPrefab;

	private float _speed=0.99f;

	private GameObject[] fruit;

	private GameObject target_fruit;

	private float distance;

	private bool orientation;

	private float rotation;

	private Vector3 lastpos;

//	private float frameRate = 0.1f;

//	private float step = 1f;

//	void Start() {
//		InvokeRepeating("Move",frameRate,frameRate);
//	}

	void Move(){
		lastpos = transform.position;

		if (orientation) {
			rotation = 1;
		} else{
			rotation = -1;
		}

		transform.rotation = Quaternion.Euler(0f,0f,rotation) * transform.rotation ;
		transform.position = Vector3.MoveTowards(transform.position,transform.GetChild(0).transform.position,Time.deltaTime);
//		transform.position *= step;
		MoveTail();
	}
	
	void MoveTail(){
		for (int i = 0; i < tail.Count; i++) {
			Vector3 temp = tail [i].position;
			tail [i].position = Vector3.MoveTowards(tail[i].position,lastpos,(_speed-(0.01f*i))*Time.deltaTime);
			lastpos = temp;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		fruit = GameObject.FindGameObjectsWithTag("Fruit");
		if (Input.GetKey (KeyCode.Z)) {
			orientation = false;
		} else if (Input.GetKey (KeyCode.M)) {
			orientation = true;
			}
		target_fruit = fruit[0];
		distance = Vector3.Distance(transform.position,target_fruit.transform.position);
		Move ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Block")){
			print ("Has Perdido");
		}
		else if (distance <= 0.1f){
			tail.Add(Instantiate(TailPrefab,tail[tail.Count-1].position,Quaternion.identity).transform);
			//col.transform.position = new Vector2 (Random.Range(horizontalRange.x,horizontalRange.y),Random.Range(verticalRange.x,verticalRange.y));
		}
	}
}