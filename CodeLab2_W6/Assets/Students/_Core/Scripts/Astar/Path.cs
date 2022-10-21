using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path {

	public string pathName;
	public int nodeInspected;

	//The whole grid map
	public GridScript gridScipt;
	//path is a list of steps
	public List<Step> path = new List<Step>();

	//The whole cost of the path
	public float score;
	public int steps;

	//Constructor
	public Path(string name, GridScript gridScipt){
		this.gridScipt = gridScipt;
		pathName = name;
	}

	//Get the step in this path by index
	public Step Get(int index){
		return path[index];
	}
	
	//Insert a step into the path
	public virtual void Insert(int index, GameObject go){
		float stepCost = gridScipt.GetMovementCost(go);
		score += stepCost;
		
		path.Insert(index, new Step(go, stepCost));
		
		steps++;
	}

	public virtual void Insert(int index, GameObject go, Vector3 gridPos){
		float stepCost = gridScipt.GetMovementCost(go);
		score += stepCost;
		
		path.Insert(index, new Step(go, stepCost, gridPos));

		steps++;
	}
}
