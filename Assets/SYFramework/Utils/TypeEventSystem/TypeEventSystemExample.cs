using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class TypeEventSystemExample : MonoBehaviour
	{
		public class PlayerInfo
		{
			public object age;

			public object name;
		}
		void Start()
		{
			//注册事件
			TypeEventSystem.Register<PlayerInfo>(PlayerInfoCallback);

		}


		private void PlayerInfoCallback(PlayerInfo playerInfo)
		{

			string name = (string)playerInfo.name;
			int age = (int)playerInfo.age;
			Debug.Log("玩家姓名："+name+"\n 年龄："+age);
		}
		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				TypeEventSystem.Send(new PlayerInfo() { name = "小红", age = 20 });
			}
		}
	}

}
