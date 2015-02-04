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
	CircleCollider2D circleCollider2d;

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

					moveDrop = Object.Instantiate(col.transform.gameObject) as GameObject;
					moveDrop.AddComponent("MoveDrop");
					moveDrop.AddComponent ("Rigidbody2D");
					moveDrop.rigidbody2D.gravityScale = 0;
					circleCollider2d = moveDrop.GetComponent<CircleCollider2D> ();
					circleCollider2d.radius = 0.01f;

					tapDrop.renderer.material.color = new Color(1,1,1,0.5f);
					tapDrop.collider2D.enabled = false;
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
					tapDrop.renderer.material.color = new Color(1,1,1,1);
					tapDrop.collider2D.enabled = true;
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
