using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class TestExtension : StaticThisExtensionExample
	{
		private void Awake()
		{
			//this 直接调用
			this.Hide();
		}
	}

}
