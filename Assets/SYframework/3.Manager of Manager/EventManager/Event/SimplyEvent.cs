using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework.LQ
{
	public class SimplyExample : MonoBehaviourSimplify
	{

#if UNITY_EDITOR
		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/3.event 测试",false,3)]
		private static void MuteOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			new GameObject("SimplyEvent").AddComponent<SimplyExample>();
		}

#endif
		private void Awake()
		{
			Register("ben", (obj) => { Debug.Log(obj.ToString()); });
			transform.position = new Vector3(10,50,100);
		}
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//MsgSystem.Send("abc", "这是space 发出的消息");
				//发送消息 带参数
				this.Send(MsgID.sendMsg, "sendmsg id");
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				
				this.Send("abc", "这是A 发出的消息");
			}
			if (Input.GetKeyDown(KeyCode.B))
			{
				this.Send("on", "ben fa");
			}
			if (Input.GetKey(KeyCode.Alpha1))
			{
				Debug.Log("??");

				//transform.Identity();
				//transform.SetLocalPosX(Time.deltaTime * 10);

			}
		}

		protected override void OnBeforOnDestroy()
		{
			Destroy(gameObject);
		}
	}

}
