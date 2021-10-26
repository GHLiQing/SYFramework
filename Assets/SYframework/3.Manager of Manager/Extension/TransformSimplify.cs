using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	/// <summary>
	/// 静态扩展 this 用于 MonoBehaviour 调用
	///  类: static 
	///  方法: static
	///  形参: this 前缀
	///  在mono直接thi调用扩展
	/// </summary>
	public static partial class TransformExtension
	{
		/// <summary>
		/// 重置操作
		/// </summary>
		/// <param name="trans">Trans.</param>
		public static void Identity(this Transform trans)
		{
			trans.localPosition = Vector3.zero;
			trans.localScale = Vector3.one;
			trans.localRotation = Quaternion.identity;
		}
		/// <summary>
		/// 单独设置x的值
		/// </summary>
		/// <param name="transform"></param>
		/// <param name="x"></param>
		public static void SetLocalPosX(this Transform transform, float x)
		{
			var localPos = transform.localPosition;
			localPos.x = x;
			transform.localPosition = localPos;
		}

		public static void SetLocalPosY(this Transform transform, float y)
		{
			var localPos = transform.localPosition;
			localPos.y = y;
			transform.localPosition = localPos;
		}

		public static void SetLocalPosZ(this Transform transform, float z)
		{
			var localPos = transform.localPosition;
			localPos.z = z;
			transform.localPosition = localPos;
		}

		public static void SetLocalPosXY(this Transform transform, float x, float y)
		{
			var localPos = transform.localPosition;
			localPos.x = x;
			localPos.y = y;
			transform.localPosition = localPos;
		}

		public static void SetLocalPosXZ(this Transform transform, float x, float z)
		{
			var localPos = transform.localPosition;
			localPos.x = x;
			localPos.z = z;
			transform.localPosition = localPos;
		}

		public static void SetLocalPosYZ(this Transform transform, float y, float z)
		{
			var localPos = transform.localPosition;
			localPos.y = y;
			localPos.z = z;
			transform.localPosition = localPos;
		}

		public static void AddChild(this Transform transform, Transform childTrans)
		{
			childTrans.SetParent(transform);
		}
	}
}
