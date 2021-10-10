using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021
{
	public class TestModule : IEditorPlatformModule
	{


		public void OnGUI()
		{
			GUILayout.Label("这个是一个新的模块", new GUIStyle()
			{
				fontSize = 30
			});

			
		}

	}
}

