using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
public  static class LogFileName 
{
	[MenuItem("QFramework/1.生产 unityPackage 名字")]
    public static void Log()
	{
		Debug.Log("QFramwork" + DateTime.Now.ToString());
	}
	[MenuItem("QFramework/2.复制文本到剪切板")]
	public static void CopyText()
	{
		GUIUtility.systemCopyBuffer = "需要复制的文字";
	}
	[MenuItem("QFramework/3.生产文件名到剪切板")]
	public static void MenuOnClick()
	{
		GUIUtility.systemCopyBuffer = "QFramwrok" + DateTime.Now.ToString("yyyymmdd_hh");
	}
	[MenuItem("QFramework/4.导出unitypackage")]
	public static void MenuClick()
	{
		string assetPath = "Assets/QFramework";//需要打包的路径名字
		string friName = "QFramework_" + DateTime.Now.ToString("yyyymmdd_hh")+ ".unitypackage";//导出文件名
		AssetDatabase.ExportPackage(assetPath, friName,ExportPackageOptions.Recurse); //Recurse:
		//Default: 默认模式，Include Dependencies 为 false，不包括子目录。所以这个不是我们要的。
		//Interactive:交互选项，弹出一个窗口，这个和我们直接用默认导出相比没啥区别。所以这个也不是我们要的。
		//Recurse:递归选项，意思是说包含子目录。我们要用这个。
		//IncludeDependencies:包含依赖，不是我们需要的。
		//IncludeLibraryAssets:包含 ProjectSetting 选项，也不是我们要的。
	}
	[MenuItem("QFramework/5.打开包")]
	public static void MenuOpen()
	{
		Application.OpenURL("file:///" + Application.dataPath);
	}
	[MenuItem("QFramework/6.MenuItem 复用")]
	public static void MenuPath()
	{
		EditorApplication.ExecuteMenuItem("QFramwork/4.导出unitypackage");
		Application.OpenURL("file:///" + Path.Combine(Application.dataPath , "../") );
	}
	[MenuItem("QFramework/7.自定义快捷键 %e")]
	private static void MenuClicked()
	{
		EditorApplication.ExecuteMenuItem("QFramework/6.MenuItem 复用");
	}
}
