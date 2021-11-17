using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021
{
	public class BaseModule : IEditorPlatformModule
	{
		public PageId pageId {
			get
			{
				return PageId.BasePage;
			}
			
		}

		public void OnGUI()
		{
			GUILayout.Label("这个是一个新的模块", new GUIStyle()
			{
				fontSize = 30
			});

			
		}

	}


	public class UserMoudule : IEditorPlatformModule
	{
		public PageId pageId {
			get
			{
				return PageId.UserPage;
			}
		}

		public void OnGUI()
		{
			GUILayout.Label("这个是第二个新的模块", new GUIStyle()
			{
				fontSize = 30
			});


		}
	}
}

