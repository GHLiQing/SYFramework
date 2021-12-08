using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Example
{
	public class BindablePropretyExample : MonoBehaviour
	{
		GameDateExample dateExample;

		private void Awake()
		{
			dateExample = new GameDateExample();
			dateExample.Name.onRecive=(value)=> {

				Debug.Log(value);

			};
			dateExample.Score.Regsiter(score =>
			{
				Debug.Log("score:" + score);
			}).UnRegisterOnDestroy(gameObject);
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				dateExample.Name.Valuse = "≤‚ ‘";
				dateExample.Score.Valuse += 100;
			}
		}
	}

}
