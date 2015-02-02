using UnityEngine;
using System.Collections;

enum Type {
	FIRE,
	ICE,
	WOOD,
	LIGHT,
	DARK,
	HEAL,
	EMPTY
}

struct DropPoint{
	int h;
	int w;

	public DropPoint(int dh,int dw){
		h = dh;
		w = dw;
	}
}