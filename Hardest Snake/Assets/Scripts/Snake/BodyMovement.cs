using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour {

	private float speed;
	private Vector3 target;

	/*public void SetAttributes(float _speed, int _listPosition, List<GameObject> list) {
		speed = _speed;
		target = list[_listPosition].transform.position;
	}*/

	void Update () {
		//transform.Translate (target.normalized * speed * Time.deltaTime, Space.World);
		//transform.position = Vector3.MoveTowards (transform.position, target,speed * Time.deltaTime);
	}
}
