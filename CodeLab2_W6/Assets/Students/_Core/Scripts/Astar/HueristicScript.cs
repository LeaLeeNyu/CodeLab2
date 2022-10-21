using UnityEngine;
using System.Collections;

public class HueristicScript : MonoBehaviour {
		
	public virtual float Hueristic(int x, int y, Vector3 start, Vector3 goal, GridScript gridScript){
		//return Random.Range(0, 500);

		GameObject[,] grid = gridScript.GetGrid();
		GameObject thisGrid = grid[x, y];

		float cost = gridScript.GetMovementCost(thisGrid);
		float distance = Mathf.Abs(y - goal.y) + Mathf.Abs(x - goal.x);
		float maxDistance = Mathf.Abs(start.y - goal.y)+Mathf.Abs(start.x - goal.x);

		return (distance/maxDistance+cost);

	}
}
