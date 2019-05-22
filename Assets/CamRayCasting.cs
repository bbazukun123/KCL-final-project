using UnityEngine;
using System.Collections;

public class CamRayCasting : MonoBehaviour {

	
	
	private Vector3 oldVec;
	private Vector3 prevMousePos;
	public float sensitivity = 0.0002f;
	RaycastHit hit;
	Ray ray; 
	public Camera cam;
	ObjectManipulation hoveredObject;
	ObjectManipulation selectedObject;
	// Use this for initialization
	void Start () 
	{
		
		prevMousePos = Input.mousePosition;
		
	}
	
	void FixedUpdate()
	{
		
				ray = new Ray(transform.position, cam.transform.forward);
		
				Debug.DrawRay (ray.origin, ray.direction);

		
				if (Physics.Raycast (ray, out hit) && selectedObject == null) {
						Debug.Log ("hovering on: " + hit.transform.gameObject.name);
					if(hit.transform.gameObject.tag == "Object")
					{
						
								if(hoveredObject != (ObjectManipulation) hit.transform.gameObject.GetComponent<ObjectManipulation> ())
								{
									Debug.Log("Out of hovering!"); 
									if(hoveredObject != null)
									{
										hoveredObject.hovered = false;
									}
									
								}
								hoveredObject = hit.transform.gameObject.GetComponent<ObjectManipulation> ();
								hoveredObject.hovered = true;
						
						
					}
					
				}
				else
				{
					if(hoveredObject != null)
					{
						hoveredObject.hovered = false;
						hoveredObject = null;
					}
				}


				if(Input.GetMouseButton(0))
				{
					
					//Debug.Log("Selecting: " + hoveredObject.name); 
					if(hoveredObject != null && selectedObject == null)
					{
						selectedObject = hoveredObject;
						hoveredObject = null;
						selectedObject.hovered = false;
						selectedObject.selected = true;
						prevMousePos = Input.mousePosition;
					}

					if(selectedObject != null)
					{

						selectedObject.transform.position = new Vector3(selectedObject.transform.position.x - (prevMousePos.x - Input.mousePosition.x)*sensitivity,
				                                                selectedObject.transform.position.y - (prevMousePos.y - Input.mousePosition.y)*sensitivity,
				                                                selectedObject.transform.position.z);
						prevMousePos = Input.mousePosition;
					}	                                            
					
				}
				if(Input.GetMouseButtonUp(0))
				{
					//Debug.Log("Let go of: " + selectedObject.name);
					if(selectedObject != null)
					{
						selectedObject.selected = false;
						
					}
					selectedObject = null;
				}

	}
}
