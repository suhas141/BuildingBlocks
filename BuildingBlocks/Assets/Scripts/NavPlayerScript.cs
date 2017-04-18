﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class NavPlayerScript : MonoBehaviour {

    NavMeshAgent nav;

	// Use this for initialization
	void Start () {

        nav = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , 100))
            {
                nav.SetDestination(hit.point);
            }
        }
		
	}
}
