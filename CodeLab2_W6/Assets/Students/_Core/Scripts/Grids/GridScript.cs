using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {

	public int gridWidth;
	public int gridHeight;
	public float spacing;
	
	public Material[] mats;
	public float[] costs;

	//Set the start and goal pos in grid coordinate
	public Vector3 start = new Vector3(0,0);
	public Vector3 goal = new Vector3(14,14);
	
	//A two dimension grids array, gridArray[x,y] represents the cooresponsed grid gameobject
	GameObject[,] gridArray;
	
	public GameObject startSprite;
	public GameObject goalSprite;

	public virtual GameObject[,] GetGrid(){

		if(gridArray == null){

			gridArray = new GameObject[gridWidth, gridHeight];
			
			float offsetX = (gridWidth  * -spacing)/2f;
			float offsetY = (gridHeight * spacing)/2f;

			for(int x = 0; x < gridWidth; x++){
				for(int y = 0; y < gridHeight; y++){
					GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
					quad.transform.localScale = new Vector3(spacing, spacing, spacing);
					quad.transform.position = new Vector3(offsetX + x * spacing, 
					                                      offsetY - y * spacing, 0);

					quad.transform.parent = transform;

					gridArray[x, y] = quad;
					
					quad.GetComponent<MeshRenderer>().sharedMaterial = GetMaterial(x, y);

					//assign the goal and start sprite
					if(goal.x == x && goal.y == y){
						goalSprite.transform.position = quad.transform.position;
					}
					if(start.x == x && start.y == y){
						startSprite.transform.position = quad.transform.position;
					}
				}
			}
		}

		return gridArray;
	}

	public virtual float GetMovementCost(GameObject go){
		Material mat = go.GetComponent<MeshRenderer>().sharedMaterial;
		//int i;

		//for(i = 0; i < mats.Length; i++){
		//	if(mat.name.StartsWith(mats[i].name)){
		//		break;
		//	}
		//}

		if (CostManager.materialCost.ContainsKey(mat))
			return CostManager.materialCost[mat];
		else return 0;

		//return costs[i];
	}

	protected virtual Material GetMaterial(int x, int y){
		return mats[Random.Range(0,mats.Length)];
	}
}
