using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021
{
	public interface  IEditorPlatformModule 
	{

		PageId pageId { get; }
		/// <summary>
		/// 渲染GUI使用		
		/// </summary>
		void OnGUI();
	}
}

