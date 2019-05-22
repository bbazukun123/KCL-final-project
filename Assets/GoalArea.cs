using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class GoalArea : MonoBehaviour {

	Stopwatch sw;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		sw = new Stopwatch ();
		sw.Reset();
	}

	void OnCollisionEnter(Collision collision)
	{
		UnityEngine.Debug.Log ("Win: " + collision.gameObject.name);
		StateController.successNumber++;
		//collision.gameObject.renderer.material.SetColor ("_Color", Color.red);
		MoveState ();

	}

	public void MoveState()
	{
		if (StateController.progress != 0) 
		{
			sw.Stop();
			StateController.timeList[StateController.progress-1] = (int) sw.Elapsed.TotalSeconds;
			StateController.stateList[StateController.progress-1] = StateController.stateNumber;
			StateController.objectList[StateController.progress-1] = StateController.boxNum;

			UnityEngine.Debug.Log("State: " + StateController.stateNumber.ToString() + " Object Num: " + StateController.boxNum.ToString() + " Time: " + sw.Elapsed.TotalSeconds.ToString() + " seconds");
		}
		StateController.progress++;
		if (StateController.progress <= StateController.repetition) 
		{
						int stateNum = Random.Range (1, 3);
						StateController.stateNumber = stateNum;
						StateController .boxNum = Random.Range (1, 8);
						sw.Reset();
						sw.Start();
			
						switch (stateNum) {
						case 1:
								if(StateController.state1Count > StateController.repetition/3)
								{
									StateController.progress--;
									MoveState();
								}
								StateController.state1Count++;
								Application.LoadLevel ("State1");
								break;
						case 2:
								if(StateController.state2Count > StateController.repetition/3)
								{
									StateController.progress--;
									MoveState();
								}
								StateController.state2Count++;
								Application.LoadLevel ("State2");
								break;
						case 3:
								if(StateController.state3Count > StateController.repetition/3)
								{
									StateController.progress--;
									MoveState();
								}
								StateController.state3Count++;
								Application.LoadLevel ("State3");
								break;
						/*
						case 4:
								Application.LoadLevel ("State4");
								break;*/
				
				
						}
		} 
		else 
		{
			Application.LoadLevel ("EndScene");
		}
	}
}
