using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{

	/// <summary>
	/// ����һ��Model �ӿ�
	/// </summary>
	public interface IModel
	{
		IntReactiveProperty Score { get; }

		StringReactiveProperty Name { get; }
	}

	/// <summary>
	/// ʵ��Imodel �ӿ�
	/// </summary>
	public  class GameData : IModel
	{
		public IntReactiveProperty Score { get; } = new IntReactiveProperty() { Value = 0 };

		public StringReactiveProperty Name { get; } = new StringReactiveProperty() { Value = "" };
	}

}
