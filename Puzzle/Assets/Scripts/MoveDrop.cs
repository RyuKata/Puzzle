using UnityEngine;
using System.Collections;

public class MoveDrop : MonoBehaviour {

	public GameObject tapDrop;

	Puzzle puzzle;

	// Use this for initialization
	void Start () {
		puzzle = GameObject.Find ("Puzzle").GetComponent<Puzzle> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject colObj = col.transform.gameObject;

		SwapPos (colObj);

	}

	void SwapPos(GameObject colObj){
		Vector2 tmpPos = colObj.transform.position;

		colObj.transform.position = tapDrop.transform.position;
		tapDrop.transform.position = tmpPos;


		DropPoint colPoint = FindDrop (colObj);
		DropPoint tapPoint = FindDrop (tapDrop);
		Drop tmpDrop = puzzle.drops[colPoint.h,colPoint.w];

		puzzle.drops[colPoint.h,colPoint.w] = puzzle.drops[tapPoint.h,tapPoint.w];
		puzzle.drops[tapPoint.h,tapPoint.w] = tmpDrop;
	}

	DropPoint FindDrop(GameObject drop){
		DropPoint point = new DropPoint();

		for (var h = 0; h < Data.height; h++) {
			for (var w = 0; w < Data.width; w++) {
				if (puzzle.drops [h, w].point.ToString() == drop.name) {
					point = new DropPoint (h, w);
				}
			}
		}

		return point;
	}
}