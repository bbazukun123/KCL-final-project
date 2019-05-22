using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

public class StateController : MonoBehaviour {

	public static int boxNum;
	public static bool mouseClick;
	public static int stateNumber = 0;
	public static int successNumber = 0;
	public static int progress = 0;
	public static int repetition = 60;
	public static int state1Count = 0;
	public static int state2Count = 0;
	public static int state3Count = 0;

	public static int[] timeList;
	public static int[] stateList;
	public static int[] objectList;

	//UI
	public Text stateText = null;
	public Text progressText = null;

	// Use this for initialization
	
	void Awake() 
	{
		Debug.Log ("InAWAKEEEE!");
		DontDestroyOnLoad(transform.gameObject);
		mouseClick = false;
		boxNum = Random.Range (1, 8);

		timeList = new int[repetition];
		stateList = new int[repetition];
		objectList = new int[repetition];
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		UpdateUI ();

	}

	public void UpdateUI()
	{
		if (stateNumber != 0 && Application.loadedLevelName != "Trial") 
		{
			stateText = GameObject.Find ("Canvas").transform.GetChild (0).GetComponent<Text> ();
			progressText = GameObject.Find ("Canvas").transform.GetChild (1).GetComponent<Text> ();
		}
		
		if (stateText != null || progressText != null) 
		{
			stateText.text = "State " + stateNumber.ToString ();
			progressText.text = "Progress: " + progress.ToString () + "/" + repetition.ToString();
		}
	}
}
