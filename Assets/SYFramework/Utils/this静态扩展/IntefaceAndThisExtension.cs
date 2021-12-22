using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	public class Car
	{
		public void Door(int doors)
		{
			Debug.Log("�����ţ�"+doors+"��");
		}

		public void Wheel(int wheels)
		{
			Debug.Log("��������:"+ wheels+"��");
		}
	}

	public interface ICarInfo
	{
		Car car { get; set; }
	}

	public interface IBMWCarFarctory : ICarInfo
	{

	}
	public static class BMWCarExtension
	{
		public static void BMWDoor(this IBMWCarFarctory self,int doors)
		{
			
			self.car.Door(doors);
			
		}

		public static void BMWWheel(this IBMWCarFarctory self,int wheels)
		{
			self.car.Wheel(wheels);
		}
	}


	public interface IBCCarFactory : ICarInfo
	{

	}

	public static class BCCarExtension
	{
		public static void BCDoor(this IBCCarFactory self,int doors)
		{

			self.car.Door(doors);

		}

		public static void BCWheel(this IBCCarFactory self,int wheels)
		{
			self.car.Wheel(wheels);
		}
	}


	public class BWMCarFAarctory : IBMWCarFarctory
	{

		public Car car { get; set; }

		public BWMCarFAarctory(Car car)
		{
			this.car = car;
		}
	}

	public class BCCarFactory : IBMWCarFarctory
	{
		public Car car { get; set; }

		public BCCarFactory(Car car)
		{
			this.car = car;
		}
	}

	public class IntefaceAndThisExtension : MonoBehaviour
	{
		private void Awake()
		{
			Car car1 = new Car();
			BCCarFactory bcf = new BCCarFactory(car1);
			Debug.Log("���۹�������������Ϣ��");
			bcf.BMWDoor(4);
			bcf.BMWWheel(5);

			Car car2 = new Car();
			BWMCarFAarctory bmwf = new BWMCarFAarctory(car2);
			Debug.Log("����������������Ϣ��");
			bmwf.BMWDoor(2);
			bmwf.BMWWheel(3);

		}
	}

}
