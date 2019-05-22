using UnityEngine;
using System.Collections;

public class GoalBox : MonoBehaviour {

	//public bool isActive;
	public int boxNumber;


	void Start()
	{
		Debug.Log ("Test " + StateController.boxNum.ToString ());
		if (StateController.boxNum != boxNumber) 
		{
			gameObject.SetActive(false);
		}
		
	}

	/*
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Enter: " + collision.gameObject.name);
		if (collision.gameObject.name == StateController.boxNum.ToString ()) 
		{
			collision.gameObject.GetComponent<Renderer>().material.SetColor ("_Color", Color.green);
				
		} 
		else 
		{
			collision.gameObject.GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
		}

	}*/

	void OnCollisionStay(Collision collision)
	{
		Debug.Log ("Enter: " + collision.gameObject.name);
		if (collision.gameObject.name == StateController.boxNum.ToString ()) 
		{
			//collision.gameObject.GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");
			collision.gameObject.GetComponent<Renderer>().material.SetColor ("_Color", Color.green);
			GetComponent<Collider>().enabled = false;
			
		} 
		else 
		{
			//collision.gameObject.GetComponent<Renderer> ().material.shader = Shader.Find ("Self-Illumin/Outlined Diffuse");
			collision.gameObject.GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
		}

	}

	void OnCollisionExit(Collision collision)
	{
		Debug.Log ("Exit: " + collision.gameObject.name);
		collision.gameObject.GetComponent<Renderer> ().material.shader = collision.gameObject.GetComponent<ObjectManipulation>().initialShader;
		collision.gameObject.GetComponent<Renderer>().material.SetColor ("_Color",collision.gameObject.GetComponent<ObjectManipulation>().initialColor);
		GetComponent<Collider>().enabled = true;

	}


}
