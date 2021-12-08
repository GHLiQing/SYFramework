using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.LQ
{
	public class AudioExample : MonoBehaviourSimplify
	{
#if UNITY_EDITOR

		[UnityEditor.MenuItem("FrameworkDesign2021/Moudle/4.audioMange测试",false,4)]
		private static void MenuOnClick()
		{
			UnityEditor.EditorApplication.isPlaying = true;
			var au= new GameObject("AudioExample").AddComponent<AudioExample>();
			DontDestroyOnLoad(au);
		}
#endif

		//IEnumerator  Start()
		//{
		//	Debug.Log("加载资源");
		//	var load = Resources.Load<AudioClip>("shenbo");
		//	yield return new WaitForSeconds(10f);
		//	Resources.UnloadAsset(load);
		//	Debug.Log("卸载资源");
		//}
		private void Awake()
		{

			//AudioManager.Instance.PlaySound("Shengbo",GetComponent<AudioClip>());

			AudioManager.Instance.PlayMusic(Resources.Load<AudioClip>("bg"), true);
			this.Delay(4f, () =>
			{
				//AudioManager.GetInstance.PauseMusic() ;

				//AudioManager.Instance.SoundOff();


			});
			this.Delay(5f, () =>
			{
				//AudioManager.GetInstance.ResumeMusic();

			});
			this.Delay(10f, () =>
			{
				//AudioManager.GetInstance.StopMusic();
				//AudioManager.Instance.SoundOn();

			});
			this.Delay(15f, () =>
			{
				//AudioManager.GetInstance.PlayMusic("bg", true);


			});
			this.Delay(20f, () =>
			{
				//AudioManager.GetInstance.MusicOff();
				//Debug.Log("静音");

			});
			this.Delay(25f, () =>
			{
				//AudioManager.GetInstance.MusicOn();
				//Debug.Log("取消静音");
			});


		}



		protected override void OnBeforOnDestroy()
		{
			Destroy(gameObject);
		}
	}
}

