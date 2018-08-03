using UnityEngine;

public class BodyPartMovement : MonoBehaviour {

	public float speed;

	private Transform target;
	private Transform[] points;
	private int index;
	private float rotation;

	void Start () {
		points = new Transform[FalseRouteBehavior.points.Length];
		points = FalseRouteBehavior.points;
		index = 0;
		target = points [index];
	}

	void Update () {
		Vector3 direction = target.position - transform.position;
		float distance = direction.magnitude;

		if (distance <= 0.1f) {
			GetNextPoint();
			rotation = rotation + 90;
			transform.rotation = Quaternion.Euler(0f,0f,rotation);
		}
		transform.Translate (direction.normalized * speed * Time.deltaTime, Space.World);
	}

	void GetNextPoint() {
		if (index == points.Length - 1) {
			index = 0;
			target = points [index];
		} else {
			index++;
			target = points [index];
		}
	}
}
