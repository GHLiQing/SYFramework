using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

namespace FrameworkDesign2021
{
	public class EditorModulizationPlatformEditor : EditorWindow
	{
		/// <summary>
		/// 用来缓存模块
		/// </summary>
		public static List<IEditorPlatformModule> mModules = new List<IEditorPlatformModule>();

		/// <summary>
		/// 打开窗口
		/// </summary>
		[MenuItem("FrameworkDesign2021/0.EditorModulizationPlatform")]
		public static void Open()
		{
			var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();
			//创建一个面板
			editorPlatform.position = new Rect(
				Screen.width / 2,
				Screen.height * 2 / 3,
				600,
				500
			);

			editorPlatform.Show();

			// 清空掉之前的实例
			mModules.Clear();

			// 1.获取当前项目中所有的 assembly (可以理解为 代码编译好的 dll)
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			// 2.获取编辑器环境(dll)
			var editorAssembly = assemblies.First(assembly => assembly.FullName.StartsWith("Assembly-CSharp-Editor"));
			// 3.获取 IEditorPlatformModule 类型
			var moduleType = typeof(IEditorPlatformModule);

			mModules = editorAssembly
				// 获取所有的编辑器环境中的类型 
				.GetTypes()
				// 过滤掉抽象类型（接口/抽象类)、和未实现 IEditorPlatformModule 的类型
				.Where(type => moduleType.IsAssignableFrom(type) && !type.IsAbstract)
				// 获取类型的构造创建实例
				.Select(type => type.GetConstructors().First().Invoke(null))
				// 强制转换成 IEditorPlatformModule 类型
				.Cast<IEditorPlatformModule>()
				// 转换成 List<IEditorPlatformModule>
				.ToList();

			editorPlatform.Show();
		}

		private void OnGUI()
		{
			// 渲染
			foreach (var editorPlatformModule in mModules)
			{
				//Debug.Log(editorPlatformModule.ToString());
				editorPlatformModule.OnGUI();
			}
		}



	}
}

