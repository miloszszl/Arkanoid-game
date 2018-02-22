using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksCreator : MonoBehaviour {


	public GameObject cube5;
	public GameObject cube15;
	public GameObject cube25;


	public int CreateMap()
	{
		int sum = 0;
		int rows = Random.Range (3, 6);
	
		float paramx=0f;

		Vector3 v; 	
		for (int i = 0; i < rows; i++) 
		{
			int cols = Random.Range (2, 5);
			sum += cols;
			paramx = 8f - 2 * cols;

			for (int j = 0; j < cols; j++) 
			{
				v = new Vector3 (paramx-6f+4*j,8f-1.6f*i, 0);
				int cubeType = Random.Range (0, 3);
				Instantiate (chooseCube(cubeType), v, Quaternion.identity);
			}
		}
		return sum;
	}

	private GameObject chooseCube(int cubeType)
	{
		switch (cubeType) {
		case 0:
			return cube5;
		case 1:
			return cube15;
		default:
			return cube25;
		}
	}

	// Use this for initialization
	void Start () {
		GameController.getInstance().NumOfCubes=CreateMap();
	}
	
	/*// Update is called once per frame
	void Update () {
		
	}*/
}
