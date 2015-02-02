using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

	public GameObject[] dropObjects;

	public GameObject[,] drops = new GameObject[5,6];
	int height = 5;
	int width = 6;
	float dropSize = 1;


	// Use this for initialization
	void Start () {
		Debug.Log (Type.FIRE);
		while(true){
		  SetDrops ();

			if (checkMatch ().Count == 0) {
				break;
			}
		}
		DisplayDrops ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetDrops(){
		for (var i = 0; i < height; i++) {
			for (var j = 0; j < width; j++) {
				var type = Random.Range (0,6);
				drops[i,j] = dropObjects[type];
			}
		}
	}

	ArrayList checkMatch(){
		ArrayList matchList = new ArrayList();
//		matchList.Add (new DropPoint(1,1));
		return matchList;
	}

	void DisplayDrops(){
		for (var i = 0; i < height; i++) {
			for (var j = 0; j < width; j++) {
				var pos = new Vector3(j * 1.1f,i * 1.1f,0);
				Instantiate(drops[i,j],pos,Quaternion.identity);
			}
		}
	}
		
}
