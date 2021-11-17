using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
/// <summary>
/// 路径类  单例
/// </summary>
public class TF_ResourcesPath : Single<TF_ResourcesPath>
{
	#region 音频  字段
	private readonly string audioBgPath = "Audio/Bg";

	private readonly string audioEffectsPath = "Audio/Effects";
	//预制体路径
	private readonly string prefabsPath = "Prefabs";
	#endregion

	#region  音频属性

	public string GetAudioBg
	{
		get
		{
			return audioBgPath;
		}
	}

	public string GetAduioEffect
	{
		get
		{
			return audioEffectsPath;
		}
	}

	public string GetPerfabsPath
	{
		get
		{
			return prefabsPath;
		}
	}

	#endregion

	#region 方法

	/// <summary>
	/// 把路径体取  出来 
	/// </summary>
	/// <param name="type"></param>
	/// <param name="name"></param>
	/// <returns></returns>
	public  string GetPath(TF_PerfabsType type,string name)
	{
		string path = string.Empty;
		switch (type)
		{
			case TF_PerfabsType.Nome:
				path ="";
				break;
			case TF_PerfabsType.Cube:
				path = GetPerfabsPath + "/" + name;
				break;
			default:
				break;
		}
		return path;
	}


	public  string GetPath(TF_AudioType type,string name)
	{
		string path = string.Empty;
		switch (type)
		{
			case TF_AudioType.effects:
				path = GetAduioEffect + "/" + name;

				break;
			case TF_AudioType.bg:
				path =GetAudioBg + "/" + name;
				break;
			default:
				break;
		}
		return path;
	}

	
	#endregion
}
