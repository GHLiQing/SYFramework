using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class AudioManager : MonoSingleton<AudioManager>
	{
		/// <summary>
		/// 播放音频使用
		/// </summary>
		/// <param name="clipName"></param>
		public void PlaySound(string clipName,AudioClip clip)
		{
			IsAudioListener();
			var audioSoucre = gameObject.AddComponent<AudioSource>();
			//var clip = Resources.Load<AudioClip>(clipName);
			audioSoucre.clip = clip;
			audioSoucre.Play();
		}
		private AudioClip musicClip = null;
		private AudioSource musiceaudioSource = null;
		private AudioListener audioListener = null;

		/// <summary>
		/// 播放背景音乐
		/// </summary>
		/// <param name="musicName"></param>
		/// <param name="isPlay"></param>
		public void PlayMusic(AudioClip clip,bool isloop=true)
		{
			IsAudioListener();
			if (musiceaudioSource==null)
			{
				musiceaudioSource = gameObject.AddComponent<AudioSource>();
			}
			//musicClip = Resources.Load<AudioClip>(musicName);
			musicClip = clip;
			if (musicClip!=null)
			{
				musiceaudioSource.clip = musicClip;
				musiceaudioSource.loop = isloop;
				musiceaudioSource.Play();
			}
		}


		/// <summary>
		/// 停止音乐
		/// </summary>
		public void StopMusic()
		{
			musiceaudioSource.Stop();
		}
		/// <summary>
		/// 暂停音乐
		/// </summary>
		public void PauseMusic()
		{
			musiceaudioSource.Pause();
		}

		/// <summary>
		/// 取消暂停
		/// </summary>
		public void ResumeMusic()
		{
			musiceaudioSource.UnPause();
		}
		/// <summary>
		/// bg 静音
		/// </summary>
		public void MusicOff()
		{
			musiceaudioSource.Pause();
			musiceaudioSource.mute = true;
		}
		/// <summary>
		/// bg 取消静音
		/// </summary>
		public void MusicOn()
		{
			musiceaudioSource.UnPause();
			musiceaudioSource.mute = false;
		}

		/// <summary>
		/// 音效 静音
		/// </summary>
		public void SoundOff()
		{
			var audiocSoucre = gameObject.GetComponents<AudioSource>();
			foreach (var item in audiocSoucre)
			{
				if (item!= musiceaudioSource)
				{
					item.Pause();
					item.mute = true;
				}
			}
		}
		/// <summary>
		/// 取消静音
		/// </summary>
		public void SoundOn()
		{
			var audiocSoucre = gameObject.GetComponents<AudioSource>();
			foreach (var item in audiocSoucre)
			{
				if (item != musiceaudioSource)
				{
					item.UnPause();
					item.mute = false;
				}
			}
		}

		/// <summary>
		/// 音频监听器
		/// </summary>
		private void IsAudioListener()
		{
			if (!audioListener)
			{
				audioListener = gameObject.AddComponent<AudioListener>();
			}
		}
	}

}
