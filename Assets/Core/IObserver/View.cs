using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// ¶©ÔÄÕß IObserver
	/// </summary>
	public class View : IObserver<int>
	{
		public string Name;

		public IDisposable unDusposable;

		public View(string name)
		{
			this.Name = name;
		}
		public void OnCompleted()
		{
			Debug.Log("OnCompleted:" + Name);
		}

		public void OnError(Exception error)
		{
			Debug.Log("OnError:" + Name);
		}

		public void OnNext(int value)
		{
			Debug.Log("OnNext:" + Name+ value);
		}
	}

}
