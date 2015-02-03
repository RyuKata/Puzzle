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
	GameObject tapDrop;
	GameObject moveDrop;
	Color dropColor;

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
					tapDrop = col.transform.gameObject;
					dropColor = tapDrop.renderer.material.color;
					tapDrop.renderer.material.color = new Color(dropColor.r,dropColor.g,dropColor.b,0.5f);
					moveDrop = Object.Instantiate(col.transform.gameObject) as GameObject;
				}
			}

			//Invoke ("OperationTime", operate);
			if (Input.GetMouseButton (0)) {
				Vector2 tapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				if (tapDrop != null) {
					moveDrop.transform.position = tapPoint;
				}
			}

			if (Input.GetMouseButtonUp (0)) {
				if (tapDrop != null) {
					tapDrop.renderer.material.color = dropColor;
					tapDrop = null;
					Destroy (moveDrop);
//				state = State.COMBO;
				}
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
