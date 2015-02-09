using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour {

	[SerializeField]
	GameObject[] dropPrefabs;
	public Drop[,] drops = new Drop[5,6];

	float dropSize = 1.05f;


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
		for (var h = 0; h < Data.height; h++) {
			for (var w = 0; w < Data.width; w++) {
				var type = Random.Range (0,6);

				drops[h,w] = new Drop(dropPrefabs[type],(Data.Type)type,new DropPoint(h,w));
			}
		}
	}


	public ArrayList checkMatch(){
		ArrayList matchList = new ArrayList();

		//横にチェック
		for (var h = 0; h < Data.height; h++) {
			for (var w = 0; w < Data.width - 2; w++) {
				var countMatch = 1;
				int nextW = w;

				for (var w2 = w + 1; w2 < Data.width; w2++) {
					if (drops [h, w].type != Data.Type.EMPTY && drops [h, w].type == drops [h, w2].type) {
						countMatch++;
					} else {
						nextW = w2 - 1;
						break;
					}
				}

				if (countMatch >= 3) {
					for (var matchDrop = 0; matchDrop < countMatch; matchDrop++) {
						matchList.Add (drops[h,w + matchDrop]);
					}
				}
				w = nextW;
			}
		}

		int checkExist = matchList.Count;

		//縦にチェック
	
		for (var w = 0; w < Data.width; w++) {
			for (var h = 0; h < Data.height - 2; h++) {
				var countMatch = 1;
				int nextH = h;

				for (var h2 = h + 1; h2 < Data.height; h2++) {
					if (drops [h, w].type != Data.Type.EMPTY && drops [h, w].type == drops [h2, w].type) {
						countMatch++;
					} else {
						nextH = h2 - 1;
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
				h = nextH;
			}
		}

		return matchList;
	}


	void DisplayDrops(){
		for (var h = 0; h < Data.height; h++) {
			for (var w = 0; w < Data.width; w++) {
				var pos = new Vector3(w * dropSize,h * dropSize,0);
				GameObject drop;

				drop = (GameObject)Instantiate(drops[h,w].drop,pos,Quaternion.identity);
				drop.transform.parent = gameObject.transform;
				drop.name = drops [h, w].point.ToString ();
			}
		}
	}		

	public void Combo(){
		Debug.Log (checkMatch ().Count);
	}

}