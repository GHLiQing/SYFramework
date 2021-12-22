using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{

	/// <summary>
	/// 定义一个Model 接口
	/// </summary>
	public interface IModel
	{
		IntReactiveProperty Score { get; }

		StringReactiveProperty Name { get; }
	}

	/// <summary>
	/// 实现Imodel 接口
	/// </summary>
	public  class GameData : IModel
	{
		public IntReactiveProperty Score { get; } = new IntReactiveProperty() { Value = 0 };

		public StringReactiveProperty Name { get; } = new StringReactiveProperty() { Value = "" };
	}

}
