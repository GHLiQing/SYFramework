using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace QFramework.LQ
{
	/// <summary>
	/// 继承这个类用于扩展
	/// </summary>
	public abstract partial class MonoBehaviourSimplify:MonoBehaviour
	{

		List<MsgRecord> msgRecordsList = new List<MsgRecord>();
		//内部类 用于承载一个消息的载体
		private class MsgRecord
		{
			//栈 集合
			static Stack<MsgRecord> msgRecords = new Stack<MsgRecord>();
			//获取 对象
			public static MsgRecord Allocate(string msgName,Action<object> onRecive)
			{
				MsgRecord msgRecord = null;
				msgRecord = msgRecords.Count > 0 ? msgRecords.Pop() : new MsgRecord();
				msgRecord.Name = msgName;
				msgRecord.OnRecive = onRecive;
				return msgRecord;
			}
			//回收
			public  void Recycle()
			{
				Name = null;
				OnRecive = null;
				msgRecords.Push(this);
			}


			public string Name="";
			public Action<object> OnRecive = obj => { };
		}

		/// <summary>
		/// 发送消息
		/// </summary>
		/// <param name="key"></param>
		/// <param name="obj"></param>
		protected void Send(string key,object obj)
		{
			MsgSystem.Send(key, obj);
		}

		//注册 1
		protected void Register(string key,Action<object> onRecive)
		{
			MsgSystem.Register(key, onRecive);
			
			//这样做的理由： 减少对内存寻址的消耗  多次new对象是一种浪费的行为
			
			msgRecordsList.Add(MsgRecord.Allocate(key,onRecive));
		}

		public void UnRegister(string key)
		{
			var records = msgRecordsList.FindAll(record => record.Name == key);

			records.ForEach((rec) =>
			{
				//移除消息
				MsgSystem.UnRegister(rec.Name, rec.OnRecive);
				//从list 移除消息
				msgRecordsList.Remove(rec);
				//自身释放内存
				rec.Recycle();
			});
			msgRecordsList.Clear();

		}

		public void UnRegister(string key,Action<object> onRecive)
		{
			var records = msgRecordsList.FindAll(record => record.Name == key&&record.OnRecive==onRecive); //多加了一个判断  添加了一个回调

			records.ForEach((rec) =>
			{
				//移除消息
				MsgSystem.UnRegister(rec.Name, rec.OnRecive);
				//从list 移除消息
				msgRecordsList.Remove(rec);
				//自身释放内存
				rec.Recycle();
			});
			msgRecordsList.Clear();
		}


		//注销
		private void OnDestroy()
		{
			OnBeforOnDestroy();
			foreach (var msgrecord in msgRecordsList)
			{
				MsgSystem.UnRegister(msgrecord.Name, msgrecord.OnRecive);
				msgrecord.Recycle();
			}
			msgRecordsList.Clear();
		}

		protected abstract void OnBeforOnDestroy();
		
		/// <summary>
		/// 延时使用
		/// </summary>
		/// <param name="timer"></param>
		/// <param name="action"></param>
		public void  Delay(float timer,System.Action action)
		{
			StartCoroutine(IEDelay(timer, action));
		}

	    private IEnumerator IEDelay(float timer, System.Action mAction)
		{
			yield return new WaitForSeconds(timer);
			mAction();
		}
		/// <summary>
		/// this 静态扩展
		/// </summary>
		/// <param name="go"></param>
		public void Show(GameObject go)
		{
			gameObject.Show();
		}
		/// <summary>
		/// this 静态扩展
		/// </summary>
		/// <param name="go"></param>
		public void Hide(GameObject go)
		{
			gameObject.Hide();
		}
		/// <summary>
		/// 位置归零 静态扩展调用  
		/// 也可以 在方法中直接调用  transform.Identity();
		/// </summary>
		public void Identity()
		{
			transform.Identity();
		}

	}
}

