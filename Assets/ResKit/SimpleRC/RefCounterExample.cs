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
			Debug.Log("����");
		}

		public void Close()
		{
			Debug.Log("�ص�");
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
			Debug.Log("������"+RefCount+"��");
		}

		public void PeopleExit()
		{
			Debug.Log("�뿪һ������ʣ"+RefCount+"��");
			Release();
		}

		protected override void OnZeroRef()
		{
			light.Close();
		}
	}

}
