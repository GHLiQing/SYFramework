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
		/// �ӿڵ���ʽ���� ͨ����Ķ������
		/// </summary>
		public void CarInfor()
		{
			Debug.Log("�������Ϣ");
		}

		/// <summary>
		/// �ӿڵ���ʵ���� ͨ���ӿڵ���
		/// �˸�
		/// </summary>
		void ICar.CarType()
		{
			Debug.Log("���� ��ϵ");
		}
	}
	public class ScirptsTest : MonoBehaviour
	{
		

		private void Awake()
		{

			BmwCar car = new BmwCar();
			car.CarInfor();
			//car.CarType(); ��������� �޷�ʹ�ø÷���
			(car as ICar).CarType();//����ת�ɽӿڵ��� 
		}
	}

}
