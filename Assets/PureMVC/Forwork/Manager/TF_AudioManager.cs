using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
/// <summary>
/// 音频控制器
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class TF_AudioManager : MonoSingleton<TF_AudioManager>
{
	private AudioSource mBgAudioSouce;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		mBgAudioSouce = GetComponent<AudioSource>();
	}
	/// <summary>
	/// 播放背景音乐
	/// </summary>
	/// <param name="audioName"></param>
	public void PlayBgAudio(TF_AudioType type, string audioName)
	{
		string path = TF_ResourcesPath.Instance.GetPath(type, audioName);//把路径体取出来
		AudioClip clip = TF_ResourcesFactory.Instance. Load<AudioClip>(path);//工仓方法类
		mBgAudioSouce.clip = clip;
		mBgAudioSouce.loop = true;
		mBgAudioSouce.Play();
	}
	/// <summary>
	/// 播放一次音效
	/// </summary>
	/// <param name="audioName"></param>
	public void PlayEffectAudio(TF_AudioType type, string audioName)
	{
		//这里路径写死了 不太好 后面要改
		string path = TF_ResourcesPath.Instance.GetPath(type,audioName);
		AudioClip audioClip =TF_ResourcesFactory.Instance.Load<AudioClip>(path);
		AudioSource.PlayClipAtPoint(audioClip, transform.position);//在某个点播放音乐
	}
}
