using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӿ�-��̬��չ
/// </summary>
namespace SYFramework
{
	public class Player
	{
		public void Eat()
		{
			Debug.Log("��ҳԷ�");
		}

		public void Run()
		{
			Debug.Log("����ܲ�");
		}

		public void Sleep()
		{
			Debug.Log("���˯��");
		}
	}

	public interface IPlayerDoSomething
	{
		Player player { get; set; }
	}

	public interface IPlayerDothingEat : IPlayerDoSomething
	{

	}
	/// <summary>
	/// ��̬��չ eat
	/// </summary>
	public static class PlayerEatExtension
	{
		public static void Eat(this IPlayerDothingEat self)
		{
			self.player.Eat();
		}
	}
	public interface IPlayerDothingRunAndSleep : IPlayerDoSomething
	{

	}

	public static class PlayerRunAndSleepExtension
	{
		public static void Run(this IPlayerDothingRunAndSleep self)
		{
			self.player.Run();
		}
		public static void Sleep(this IPlayerDothingRunAndSleep self)
		{
			self.player.Sleep();
		}
	}
		 


	public class InterfaceExtension : MonoBehaviour
	{
		public class PlayerEat : IPlayerDothingEat
		{
			public Player player { get; set; } = new Player();

		}

		public class PlayerRunandSleep : IPlayerDothingRunAndSleep
		{
			public Player player { get; set; } = new Player();
		}

		private void Awake()
		{
			

			IPlayerDothingEat dothingEat = new PlayerEat();

			dothingEat.Eat();
			//dothingEat.Run(); ���������
			//dothingEat.Sleep();

			IPlayerDothingRunAndSleep runAndSleep = new PlayerRunandSleep();
			//runAndSleep.Eat(); ���������
			runAndSleep.Sleep();
			runAndSleep.Run();
		}
	}

}
