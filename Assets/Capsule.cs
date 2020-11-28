using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine;

public class Capsule : MonoBehaviour
{

	[SerializeField] private Vector3 moveUp = new Vector3(0, 1, 0);
	[SerializeField] private Vector3 moveDown = new Vector3(0, -1, 0);
	[SerializeField] private Vector3 moveLeft = new Vector3(-1, 0, 0);
	[SerializeField] private Vector3 moveRight = new Vector3(1, 0, 0);

 	[SerializeField] private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Intercept raycast hit on game object
	 	if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)) 
		{
		    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		    RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
			    if (raycastHit.collider.name == "Capsule")
			    {
					// Randomize color
					var random = new System.Random();
			 	    var list = new List<string>{ "red","blue","yellow","green"};
					int index = random.Next(list.Count);

					// Apply new color to game object
					ChangeColor(list[index]);
			    }
		    }
		}
    }

    // Change material color
    void ChangeColor(string newColor)
    {
        if (newColor == "red") GetComponent<Renderer>().material.color = Color.red;
        else if (newColor == "blue") GetComponent<Renderer>().material.color = Color.blue;
        else if (newColor == "yellow") GetComponent<Renderer>().material.color = Color.yellow;
        else if (newColor == "green") GetComponent<Renderer>().material.color = Color.green;
        else GetComponent<Renderer>().material.color = Color.black;
    }

	void MoveUp(string fake) 
	{
		transform.position = Vector3.MoveTowards(transform.position, moveUp, Time.deltaTime * speed);
	}

	void MoveDown(string fake)
	{
		transform.position = Vector3.MoveTowards(transform.position, moveDown, Time.deltaTime * speed);
	}

	void MoveLeft(string fake)
	{
		transform.position = Vector3.MoveTowards(transform.position, moveLeft, Time.deltaTime * speed);
	}

	void MoveRight(string fake)
	{
		transform.position = Vector3.MoveTowards(transform.position, moveRight, Time.deltaTime * speed);
	}

	void Unload(string fake)
	{
		Application.Unload();
	}

}
