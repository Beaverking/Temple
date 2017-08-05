using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ReceiveDamage (RaycastHit hit) {
		Bounds colliderBounds = new Bounds (hit.collider.bounds.center, hit.collider.bounds.size);
		colliderBounds.Expand (0.01f);
		Debug.Log (hit.ToString() + colliderBounds.ToString());
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		Vector3[] vertices = mesh.vertices;
		int[] tris = mesh.triangles;
		int[] newTris = new int[mesh.triangles.Length];

		if (tris.Length == 0 || vertices == null || vertices.Length == 0)
			return;

		int i = 0;
		int numTris = tris.Length;
		int numDeleted = 0;

		//lineDraws.Add (colliderBounds.center + colliderBounds.extents);

		while (i < numTris) {
			Vector3 v1Pos = gameObject.transform.TransformPoint(vertices[tris[i]]);
			Vector3 v2Pos = gameObject.transform.TransformPoint(vertices[tris[i + 1]]);
			Vector3 v3Pos = gameObject.transform.TransformPoint(vertices[tris[i + 2]]);
			bool deleteTri = colliderBounds.Contains(v1Pos) && colliderBounds.Contains(v2Pos) && colliderBounds.Contains(v3Pos);
			if (!deleteTri) {
				newTris[i] = tris[i];
				newTris[i + 1] = tris[i + 1];
				newTris[i + 2] = tris[i + 2];
			}
			else
				numDeleted++;

			i += 3;
		}

		mesh.triangles = newTris;

		hit.collider.enabled = false;
	}
}
