using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Reskit.Example
{
	public class RefCounterExample : MonoBehaviour
	{
		

		public void Awake()
		{
			Room room = new Room();
			room.PeopleEnter();
			room.PeopleEnter();

			room.PeopleExit();
			room.PeopleExit();
		}
	}


	public class Light
	{
		public void Open()
		{
			Debug.Log("开灯");
		}

		public void Close()
		{
			Debug.Log("关灯");
		}
	}
	public class Room : SimpleRC
	{
		Light light = new Light();

		public void PeopleEnter()
		{
			
			if (RefCount==0)
			{
				light.Open();
			}
			Retain();
			Debug.Log("房间有"+RefCount+"人");
		}

		public void PeopleExit()
		{
			Debug.Log("离开一个，还剩"+RefCount+"人");
			Release();
		}

		protected override void OnZeroRef()
		{
			light.Close();
		}
	}

}
