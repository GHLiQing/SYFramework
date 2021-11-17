using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Example
{
	public interface ICar
	{
		void CarInfor();
		void CarType();

	}
	public class BmwCar : ICar
	{
		/// <summary>
		/// 接口的隐式调用 通过类的对象调用
		/// </summary>
		public void CarInfor()
		{
			Debug.Log("宝马的信息");
		}

		/// <summary>
		/// 接口的现实调用 通过接口调用
		/// 阉割
		/// </summary>
		void ICar.CarType()
		{
			Debug.Log("宝马 三系");
		}
	}
	public class ScirptsTest : MonoBehaviour
	{
		

		private void Awake()
		{

			BmwCar car = new BmwCar();
			car.CarInfor();
			//car.CarType(); 报编译错误 无法使用该方法
			(car as ICar).CarType();//必须转成接口调用 
		}
	}

}
