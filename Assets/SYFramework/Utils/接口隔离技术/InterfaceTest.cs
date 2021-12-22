using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 接口-抽象类-实现类
/// 接口-静态扩展
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
		/// 接口的显示调用
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
			Debug.Log("player 开车结束");
		}

		public override void Start()
		{
			Debug.Log("player 开始开车");
		}

		public override void Updata()
		{
			Debug.Log("player 正在开车");
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

