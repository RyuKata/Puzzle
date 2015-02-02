using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

	public GameObject[] dropPrefabs;

	public Drop[,] drops = new Drop[5,6];
	int height = 5;
	int width = 6;
	float dropSize = 1.1f;


	// Use this for initialization
	void Start () {

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
		for (var h = 0; h < height; h++) {
			for (var w = 0; w < width; w++) {
				var type = Random.Range (0,6);

				drops[h,w] = new Drop(dropPrefabs[type],(Type)type,new DropPoint(h,w));
			}
		}
	}


	ArrayList checkMatch(){
		ArrayList matchList = new ArrayList();

		for (var h = 0; h < height; h++) {
			for (var w = 0; w < width - 2; w++) {
				var countMatch = 1;

				for (var w2 = w + 1; w2 < width; w2++) {
					if (drops [h, w].type != Type.EMPTY && drops [h, w].type == drops [h, w2].type) {
						countMatch++;
					} else {
						break;
					}
				}

				if (countMatch >= 3) {
					for (var matchDrop = 0; matchDrop < countMatch; matchDrop++) {
						matchList.Add (drops[h,w + matchDrop]);
					}
				}
			}
		}

		int checkExist = matchList.Count;

		for (var w = 0; w < width; w++) {
			for (var h = 0; h < height - 2; h++) {
				var countMatch = 1;

				for (var h2 = h + 1; h2 < height; h2++) {
					if (drops [h, w].type != Type.EMPTY && drops [h, w].type == drops [h2, w].type) {
						countMatch++;
					} else {
						break;
					}
				}

				if (countMatch >= 3) {
					for (var matchDrop = 0; matchDrop < countMatch; matchDrop++) {
						bool exist = false;

						for (var check = 0; check < checkExist; check++) {
							Drop checkDrop = (Drop)matchList [check];

							if (checkDrop.point == drops [h + matchDrop, w].point ) {
								exist = true;
								break;
							}
						}

						if (!exist) {
							matchList.Add (drops[h + matchDrop,w]);
						}
					}
				}
			}
		}

		return matchList;
	}


	void DisplayDrops(){
		for (var i = 0; i < height; i++) {
			for (var j = 0; j < width; j++) {
				var pos = new Vector3(j * dropSize,i * dropSize,0);
				Instantiate(drops[i,j].drop,pos,Quaternion.identity);
			}
		}
	}
		
}
