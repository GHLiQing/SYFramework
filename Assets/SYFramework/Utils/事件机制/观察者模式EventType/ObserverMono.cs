using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework
{
	public class ObserverMono : MonoBehaviour
	{
		private void Awake()
		{
			//eventTypeSystem
			Observer observer1 = new Observer();
			Observer observer2 = new Observer();
			Subject subject = new Subject();
			subject.InsterentThing();




		}
	}
}

