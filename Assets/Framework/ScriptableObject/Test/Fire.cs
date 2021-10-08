using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

	public GameObject bullet;
    void Start()
    {
        
    }

    
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{

			Vector3 point= Camera.main.WorldToScreenPoint(transform.position);
			Vector3 mouspos = Input.mousePosition;
			point = new Vector3(mouspos.x, mouspos.y, point.z);
			Vector3 screenpoint = Camera.main.ScreenToWorldPoint(point);
			GameObject bullets= Instantiate(bullet, transform,true);
			bullets.transform.position = screenpoint;


		}   
    }

	
}
