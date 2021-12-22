using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Example
{
	public class BindablePropretyExample : MonoBehaviour
	{
	

		private void Awake()
		{
			GameDateExample.Instance.Name.onRecive=(value)=> {

				Debug.Log(value);

			};
			GameDateExample.Instance.Score.Regsiter(score =>
			{
				Debug.Log("score:" + score);
			}).UnRegisterOnDestroy(gameObject);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameDateExample.Instance.Name.Valuse = "≤‚ ‘";
				GameDateExample.Instance.Score.Valuse += 100;
			}
		}
	}

}
