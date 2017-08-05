using UnityEngine;
using System.Collections;

public class GenerateHouse : MonoBehaviour {

	public int width;
	public int heigth;

	public GameObject floor;
	public GameObject ceiling;
	public GameObject roofBorder;
	public GameObject roofBorderCorner;
	public GameObject externalWallFront;
	public GameObject cornerFR;
	public GameObject cornerFL;

	// Use this for initialization
	void Start () {
		if (floor == null || externalWallFront == null || cornerFR == null || cornerFL == null) {
			Debug.LogError("Can't generate house: one of the elements object is not set.");
			return;
		}

		float gSize = LevelSettings.gridSize;
		float hSize = gSize * 0.5f;

		Quaternion rot = Quaternion.identity;
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f));

		//Floor
		for (int j = 0; j < heigth; j++) {
			for (int i = 0; i < width; i++) {
				Instantiate(floor, new Vector3(gSize * i + hSize, 0.0f, gSize * j + hSize), rot);
				Instantiate(ceiling, new Vector3(gSize * i + hSize, 2.5f, gSize * j + hSize), rot);
			}
		}

		//Corners
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 1.0f, 0.0f));
		Instantiate(cornerFR, new Vector3 (0.0f + hSize, 0.0f, 0.0f + hSize), rot);
		Instantiate(roofBorderCorner, new Vector3 (0.0f + hSize, 2.5f, 0.0f + hSize), rot);
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (-1.0f, 0.0f, 0.0f));
		Instantiate(cornerFL, new Vector3 (0.0f + hSize, 0.0f, 0.0f + hSize), rot);
		GameObject go = (GameObject) Instantiate(roofBorderCorner, new Vector3 (0.0f + hSize, 2.5f, 0.0f + hSize), rot);
		Vector3 scale = go.transform.localScale;
		scale.x = -scale.x;
		go.transform.localScale = scale;
		//go.transform = tr;
		// LB

		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (-1.0f, 0.0f, 0.0f));
		Instantiate(cornerFR, new Vector3 (0.0f + hSize, 0.0f, heigth * gSize - hSize), rot);
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f));
		Instantiate(cornerFL, new Vector3 (0.0f + hSize, 0.0f, heigth * gSize - hSize), rot);
		// LU

		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f));
		Instantiate(cornerFR, new Vector3 (width * gSize - hSize, 0.0f, heigth * gSize - hSize), rot);
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (1.0f, 0.0f, 0.0f));
		Instantiate(cornerFL, new Vector3 (width * gSize - hSize, 0.0f, heigth * gSize - hSize), rot);
		// RU

		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (1.0f, 0.0f, 0.0f));
		Instantiate(cornerFR, new Vector3 (width * gSize - hSize, 0.0f, 0.0f + hSize), rot); 
		rot.SetLookRotation (new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, -1.0f));
		Instantiate(cornerFL, new Vector3 (width * gSize - hSize, 0.0f, 0.0f + hSize), rot);
		// RB

		//Walls
		for (int i = 1; i < width - 1; i++) {
			rot.SetLookRotation(new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, 1.0f));
			Instantiate(externalWallFront, new Vector3 (i * gSize + hSize, 0.0f, heigth * gSize - hSize), rot);
			Instantiate(roofBorder, new Vector3 (i * gSize + hSize, 2.5f, heigth * gSize - hSize), rot);
			rot.SetLookRotation(new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (0.0f, 0.0f, -1.0f));
			Instantiate(externalWallFront, new Vector3 (i * gSize + hSize, 0.0f, 0.0f + hSize), rot);
			Instantiate(roofBorder, new Vector3 (i * gSize + hSize, 2.5f, 0.0f + hSize), rot);
		}

		for (int i = 1; i < heigth - 1; i++) {
			rot.SetLookRotation(new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (-1.0f, 0.0f, 0.0f));
			Instantiate(externalWallFront, new Vector3(0.0f + hSize, 0.0f, i * gSize + hSize), rot);
			Instantiate(roofBorder, new Vector3(0.0f + hSize, 2.5f, i * gSize + hSize), rot);
			rot.SetLookRotation(new Vector3 (0.0f, 1.0f, 0.0f), new Vector3 (1.0f, 0.0f, 0.0f));
			Instantiate(externalWallFront, new Vector3(width * gSize - hSize, 0.0f, i * gSize + hSize), rot);
			Instantiate(roofBorder, new Vector3(width * gSize - hSize, 2.5f, i * gSize + hSize), rot);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
