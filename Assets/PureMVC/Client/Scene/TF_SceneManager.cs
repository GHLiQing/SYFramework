using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SYFramework;
public class TF_SceneManager : Single<TF_SceneManager>
{
	private string scenename; //去的场景

	private AsyncOperation ony;

	private float progress;

	public float Progress
	{
		get
		{
			return progress;
		}
	}
	/// <summary>
	/// 切换场景
	/// </summary>
	public void ChangeScene(string sceneName)
	{
		this.scenename = sceneName;
		SceneManager.LoadScene(EnumSceneName.LoadingScene);

		
	}

	public IEnumerator LoadScene()
	{
		ony= SceneManager.LoadSceneAsync(scenename);
		ony.allowSceneActivation = false;
		
		while (ony.progress < 0.9f)
		{
			progress+=0.001f;
			
			yield return 0;
		}

		while (progress<1)
		{
			progress += 0.001f;
			yield return 0;
		}
		ony.allowSceneActivation = true;
		yield return 0;
	}
}
