using UnityEngine;
using System.Collections;


public class ObjectManipulation : MonoBehaviour {

	/*

	*/

	Vector3 screenPoint, offset;
	bool onDrag,justExit;
	public Shader initialShader;
	public Color initialColor;
	//children
	public Color child1InitColor;
	public Color child2InitColor;
	

	public bool selected;
	public bool hovered;

	public void Start()
	{
		if (transform.childCount > 0) 
		{
				
		} 
		else 
		{
			initialColor = GetComponent<Renderer> ().material.color;
			initialShader = GetComponent<Renderer> ().material.shader;	
		}
			
	}

	public void FixedUpdate()
	{
		if (hovered) 
		{
						//GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");	
						if(transform.childCount > 0)
						{
							transform.GetChild (0).GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
							transform.GetChild (1).GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
						} 
						else
						{
							GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
						}
						
		} 
		else if(selected)
		{
						if(transform.childCount > 0)
						{
							transform.GetChild (0).GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
							transform.GetChild (1).GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
						} 
						else
						{
				//GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");
								GetComponent<Renderer>().material.SetColor ("_Color", Color.yellow);
								
						}
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().freezeRotation = true;
			
		}
		else if(!selected)
		{
				if(transform.childCount > 0)
				{
					transform.GetChild (0).GetComponent<Renderer>().material.color = initialColor;
					transform.GetChild (1).GetComponent<Renderer>().material.color = initialColor;
				} 
				else
				{
				//GetComponent<Renderer> ().material.shader = initialShader;	
				GetComponent<Renderer> ().material.color = initialColor;	

				}
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody>().freezeRotation = false;
		}

	}


	/*
	void OnMouseDown()
	{
		StateController.mouseClick = true;
		screenPoint = Camera.main.WorldToScreenPoint (transform.position);

		offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

	}*/

	void OnMouseDrag()
	{
		Debug.Log ("Dragging");
		onDrag = true;
		justExit = false;
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;

		//transform.position = curPosition;
		GetComponent<Rigidbody>().MovePosition(curPosition);
		GetComponent<Rigidbody>().freezeRotation = true;

		/*
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
		Vector3 objPos = Camera.main.ScreenToWorldPoint (mousePos);
		rigidbody.freezeRotation = true;*/

		//transform.position = objPos;

	}

	/*
	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.name == "Box" && !justExit) 
		{
			Debug.Log("In Here");
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
			
			transform.position = curPosition;
			rigidbody.freezeRotation = true;
			justExit = true;

		}
	}
	*/


	void OnMouseUp() 
	{
		StateController.mouseClick = false;
		onDrag = false;
		GetComponent<Rigidbody>().freezeRotation = false;
	}
	
	/*
	void OnMouseOver() { GetComponent<Renderer>().material.color = Color.yellow; }
	
	void OnMouseExit() { GetComponent<Renderer>().material.color = initialColor; }
	*/
	/*
	void OnMouseOver()
	{
		if (!StateController.mouseClick) 
		{
				GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");
				//GetComponent<Renderer> ().material.shader = Shader.Find ("Outlined/Silhouetted Diffuse");
		}
	}*/
	
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.shader = initialShader;
	}


}
