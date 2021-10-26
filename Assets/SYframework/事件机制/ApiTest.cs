using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework.LQ.Evnet
{
	public class Test
	{
		public object name;
		public Test(object name)
		{
			this.name = name;
		}
	}
	public class Test2
	{

	}

	public class ApiTest : MonoBehaviour
	{
		

		//适合模块内部之间消息的发送 创建服务对象也只是创建了服务对象 而并没有创建一个内部消息机制 使用的还是一个消息机制
		public EventService eventService = new EventService();

		private void Awake()
		{
			eventService.Register<Test>(TestCallback);

			//适合全局消息发送 也就是全局发送
			TypeEventSystem.Register<Test2>((Test) =>
			{
				Debug.Log("直接调用 TypeEventSystem");

			});
		
			
		}

		private void Update()
		{
			//if (Input.GetKeyDown(KeyCode.Space))
			//{
			//	eventService.Send(new Test());
			//}
		}
		private void OnDestroy()
		{
			eventService.RegisterAll();
		}
		public void TestCallback(Test test)
		{
			Debug.Log("回调 封装好的api  server 服务"+test.name);
		}
	}
}

