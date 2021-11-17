using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
/// <summary>
/// 加载资源  音频 图片  视频 
/// 单例类
/// </summary>
public class TF_ResourcesFactory : Single<TF_ResourcesFactory>
{
   /// <summary>
   /// 加载资源
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="path"></param>
   /// <returns></returns>
	public  T Load<T>(string path) where T:Object
	{
		return Resources.Load<T>(path);
	}
}
