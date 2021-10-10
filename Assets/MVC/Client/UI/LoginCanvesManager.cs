using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginCanvesManager : TF_View
{
	private Button mLoginBtn;

	public override string Name => typeof(LoginCanvesManager).Name;

	private void Awake()
	{
		mLoginBtn = GameObject.Find("UICamera/LoginCanvas/LoginBtn").GetComponent<Button>();
		mLoginBtn.onClick.AddListener(LoginSceneOnClick);
		TF_AudioManager.Instance.PlayBgAudio(TF_AudioType.bg, "Charlie Puth - Look At Me Now");
	}


	public void LoginSceneOnClick()
	{
		//TF_SceneManager.Instance.ChangeScene(EnumSceneName.SelectScene);
		//发送场景切换的通知
		SendNotification(NotificationConst.LoadSceneCommand, EnumSceneName.SelectScene);	
	}

	private void OnDisable()
	{
		mLoginBtn.onClick.RemoveListener(LoginSceneOnClick);
	}
}
