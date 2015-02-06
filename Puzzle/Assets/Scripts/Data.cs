using UnityEngine;
using System.Collections;

public class Data {
	public const int height = 5;
	public const int width = 6;
	public enum Type {
		FIRE,
		ICE,
		WOOD,
		LIGHT,
		DARK,
		HEAL,
		EMPTY
	}
}
	
public struct DropPoint{
	public int h;
	public int w;

	public DropPoint(int dh,int dw){
		h = dh;
		w = dw;
	}

	public static bool operator == (DropPoint a,DropPoint b){
		return (a.h == b.h && a.w == b.w);
	}
	public static bool operator != (DropPoint a,DropPoint b){
		return !(a.h == b.h && a.w == b.w);
	}

	public override string ToString (){
		return ""+h+w;
	}
}

public struct Drop {
	public GameObject drop;
	public Data.Type type;
	public DropPoint point;

	public Drop(GameObject drop,Data.Type type,DropPoint point){
		this.drop = drop;
		this.type = type;
		this.point = point;
	}
}