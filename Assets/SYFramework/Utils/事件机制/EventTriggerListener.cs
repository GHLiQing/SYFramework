using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace SYFramework.LQ
{
	public class EventTriggerListener : EventTrigger
	{
		public delegate void VoidDelegate(GameObject go);

		public VoidDelegate onClick;
		public VoidDelegate onDown;
		public VoidDelegate onEnter;
		public VoidDelegate onExit;
		public VoidDelegate onUp;
		public VoidDelegate onSelect;
		public VoidDelegate onDeselect;
		public VoidDelegate onUpdayeSelect;
		public VoidDelegate onDrag;

		public VoidDelegate onDoublelick;
		public VoidDelegate onPointStay;

		private bool isEnter;
		private float t1, t2;//点击事件
		private void Update()
		{
			if (isEnter)
			{
				onPointStay?.Invoke(gameObject);
			}
		}

		public static EventTriggerListener Get(GameObject go)
		{
			EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
			if (listener==null)
			{
				listener = go.AddComponent<EventTriggerListener>();
			}
			return listener;
		}
		/// <summary>
		/// 鼠标移入回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerEnter(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID == EventTriggerType.PointerEnter)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onEnter?.Invoke(gameObject);
			isEnter = true;
		}

		/// <summary>
		/// 鼠标移除回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerExit(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID==EventTriggerType.PointerExit)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onExit?.Invoke(gameObject);
			isEnter = false;
		}

		/// <summary>
		/// 鼠标拖拽回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnDrag(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID == EventTriggerType.Drag)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onDrag?.Invoke(gameObject);
		}

		/// <summary>
		/// 鼠标点击回调 
		/// 可以点击两次
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerDown(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID == EventTriggerType.PointerDown)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onDown?.Invoke(gameObject);
			if (Input.GetMouseButtonDown(0))
			{
				t2 = Time.time;
				if (t2-t1<0.4f)
				{
					onDoublelick?.Invoke(gameObject);
				}
				t1 = t2;
			}
		}
		/// <summary>
		/// 鼠标抬起回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerUp(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID==EventTriggerType.PointerUp)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onUp?.Invoke(gameObject);

		}
		/// <summary>
		/// 鼠标点击回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnPointerClick(PointerEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID==EventTriggerType.PointerClick)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onClick?.Invoke(gameObject);
		}


		/// <summary>
		/// 鼠标选择回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnSelect(BaseEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID== EventTriggerType.Select)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onSelect?.Invoke(gameObject);
		}

		/// <summary>
		/// 取消选择回调
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnDeselect(BaseEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID == EventTriggerType.Deselect)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onDeselect?.Invoke(gameObject);
		}

		
		/// <summary>
		/// 鼠标选择一直回到
		/// </summary>
		/// <param name="eventData"></param>
		public override void OnUpdateSelected(BaseEventData eventData)
		{
			for (int i = 0; i < triggers.Count; i++)
			{
				if (triggers[i].eventID== EventTriggerType.UpdateSelected)
				{
					triggers[i].callback.Invoke(eventData);
				}
			}
			onUpdayeSelect?.Invoke(gameObject);
		}
	}
}

