using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayCastFromCamera : MonoBehaviour {

	private float maxRayCastDist = 500.0f;
	private int destructionMask = 1 << 8;

	private List<Vector3> rayStarts = new List<Vector3>();
	private List<Vector3> rayEnds = new List<Vector3>();

	// Use this for initialization
	void Start () {
		rayStarts.Clear ();
		rayEnds.Clear ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(r, out hit, maxRayCastDist, destructionMask)) {
				rayStarts.Add(gameObject.transform.position);
				rayEnds.Add(hit.point);

				Destruction destruction = hit.collider.gameObject.GetComponent<Destruction>();
				if (destruction == null)
					Debug.LogWarning("Camera ray hit game object that doesn't have destruction component");
				else
					destruction.ReceiveDamage(hit);
			}
		}

		int rayCount = rayStarts.Count;
		for (int i = 0; i < rayCount; ++i) {
			Debug.DrawLine(rayStarts[i], rayEnds[i], Color.cyan);
		}
	}
}
