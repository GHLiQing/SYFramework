using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LQFramework
{
	public class TestPool : MonoBehaviour
	{

	
		void Start()
		{
			 GameObject cube=  ObjectPoolManager.Instance.Spawn(PrefabsType.prefab, "Cube", transform.position, transform.rotation, transform);

			
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				ObjectPoolManager.Instance.Spawn(PrefabsType.prefab, "Cube", transform.position, transform.rotation, transform);
			}

			
		}
	}

}
