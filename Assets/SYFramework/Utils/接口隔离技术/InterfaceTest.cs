using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӿ�-������-ʵ����
/// �ӿ�-��̬��չ
/// </summary>
namespace SYFramework
{
	public interface ICanDriveCar
	{
		void OnStart();
		void OnUpdate();
		void OnExit();

	}

	public abstract class CanDriveCar : ICanDriveCar
	{
		public bool Isbegin = false;
		public bool IsOver = false;

		/// <summary>
		/// �ӿڵ���ʾ����
		/// </summary>
		void ICanDriveCar.OnExit()
		{
			IsOver = true;
			Exit();
		}

		void ICanDriveCar.OnStart()
		{
			Isbegin = true;
			Start();
		}

		void ICanDriveCar.OnUpdate()
		{
			Updata();
		}


		public abstract void Start();
		public abstract void Updata();

		public abstract void Exit();
	}

	public class PlayerDriveCar : CanDriveCar
	{
		public override void Exit()
		{
			Debug.Log("player ��������");
		}

		public override void Start()
		{
			Debug.Log("player ��ʼ����");
		}

		public override void Updata()
		{
			Debug.Log("player ���ڿ���");
		}
	}

	public class InterfaceTest : MonoBehaviour
	{

		public ICanDriveCar icanDriveCar;
		private void Awake()
		{
			icanDriveCar =new PlayerDriveCar();
			icanDriveCar.OnStart();

		}

		private void Update()
		{
			icanDriveCar.OnUpdate();
		}

		private void OnDestroy()
		{
			icanDriveCar.OnExit();
		}
	}
}

