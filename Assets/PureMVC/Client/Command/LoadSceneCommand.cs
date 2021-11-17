using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加载场景
/// 命令
/// </summary>
public class LoadSceneCommand : TF_Controller
{
	public override void Execute(object data = null)
	{
		TF_SceneManager.Instance.ChangeScene(data as string);
	}
}
