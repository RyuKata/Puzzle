using UnityEngine;
using System.Collections;

public enum Type {
	FIRE,
	ICE,
	WOOD,
	LIGHT,
	DARK,
	HEAL,
	EMPTY
}

public struct DropPoint{
	int h;
	int w;

	public DropPoint(int dh,int dw){
		h = dh;
		w = dw;
	}

	public static bool operator== (DropPoint a,DropPoint b){
		return (a.h == b.h && a.w == b.w);
	}
	public static bool operator!= (DropPoint a,DropPoint b){
		return !(a.h == b.h && a.w == b.w);
	}
}

public struct Drop {
	public GameObject drop;
	public Type type;
	public DropPoint point;

	public Drop(GameObject drop,Type type,DropPoint point){
		this.drop = drop;
		this.type = type;
		this.point = point;
	}
}