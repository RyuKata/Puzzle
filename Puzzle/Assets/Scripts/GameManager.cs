using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	enum State{
		WAIT,
		PUZZLE,
		COMBO,
		ATTACK,
		ENEMYATTACK,
		CLEAR,
		GAMEOVER
	}

	int operate = 4;
	State state;
	GameObject tapObj;

	// Use this for initialization
	void Start () {
		state = State.WAIT;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.WAIT:
			state = State.PUZZLE;
			break;
		case State.PUZZLE:
			if (Input.GetMouseButtonDown (0)) {
				Vector2 tapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Collider2D col = Physics2D.OverlapPoint (tapPoint);

				if (col) {
					tapObj = col.transform.gameObject;
				}
			}

			//Invoke ("OperationTime", operate);
			if (Input.GetMouseButton (0)) {
				Vector2 tapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				if (tapObj != null) {
					tapObj.transform.position = tapPoint;
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				tapObj = null;
//				state = State.COMBO;
			}

			break;
		case State.COMBO:
			break;
		case State.ATTACK:
			break;
		case State.ENEMYATTACK:
			break;
		case State.CLEAR:
			break;
		case State.GAMEOVER:
			break;
		default:
			break;
		}
	}

	void OperationTime(){
		state = State.COMBO;
	}
}
