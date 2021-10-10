using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.LQ.Evnet
{

	public class Person
	{

	}

	public class MonoService : MonoBehaviour
	{
		EventService service = new EventService();

		private void Awake()
		{
			service.Register<Person>(person => {

				Debug.Log("注册");
			});
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//service.Send<Person>(new Person());
				service.Send(new Test("小红"));
			}
		}
	}
}

