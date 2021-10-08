using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public BulletConfig bulletConfig;
	private void Awake()
	{
		if (bulletConfig.IsGravity)
		{
			GetComponent<Rigidbody>().velocity = Vector3.forward * bulletConfig.G_MoveSpeed;
		}
		else
		{
			GetComponent<Rigidbody>().velocity = Vector3.forward * bulletConfig.NoG_MoveSpeed;
		}  
		
	}

}
