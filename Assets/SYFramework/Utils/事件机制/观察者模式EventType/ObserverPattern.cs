using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class ObserverPattern:MonoBehaviour
	{

		 abstract class SubjectBase
		{
			 List<ObserverBase> observerBasesList = new List<ObserverBase>();

			public void AddObserver(ObserverBase observerBase)
			{
				observerBasesList.Add(observerBase);
			}

			public void RemoveObserver(ObserverBase observerBase)
			{
				observerBasesList.Remove(observerBase);
			}

			public void Notify()
			{
				observerBasesList.ForEach(observer => observer.Update());
			}
		}


	    class CurrentSubject: SubjectBase
		{
			private string subjectState = "";
			public void SetState(string state)
			{
				subjectState = state;
				Notify();
			}

			public string GetState()
			{
				return subjectState;
			}
		}

		abstract class ObserverBase
		{
			public abstract void Update();
		}

		class CurrentObserver : ObserverBase
		{
			
			private CurrentSubject currentSubject = null;

			public CurrentObserver(CurrentSubject subject)
			{
				currentSubject = subject;
			}

			public override void Update()
			{
				Debug.Log("通知者："+currentSubject.GetState());
			}
		}

		private void Start()
		{
			var currentsubeject = new CurrentSubject();
			var currentObserver = new CurrentObserver(currentsubeject);
			currentsubeject.AddObserver(currentObserver);
			currentsubeject.SetState("开始状态");
		}

	}




}

