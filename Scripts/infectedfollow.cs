using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectedfollow : MonoBehaviour {
	public GameObject gos;
	public GameObject go;
	public GameObject target;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2.3f);
		gameObject.tag = "infectedenemy"; 	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.LookAt();

		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("hostilefollower");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}

		//print(closest.transform.position.x);
		target=closest;
	
		transform.LookAt (new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z));
		//transform.Translate(Vector3.right*5.5f*Time.deltaTime);	
		transform.Translate(Vector3.forward*8f*Time.deltaTime);	
	}
	/*
		GameObject FindClosestEnemy()
		{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("hostilefollower");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}

		print(closest.transform.position.x);
		return closest;
	}
	*/
}
