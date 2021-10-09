using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
namespace SYFramework
{
	public class UniRxPanel : MonoBehaviour
	{
		public Button send_Btn;

		public Text score_Txt;

		public Text gameName_txt;
	
		private void Awake()
		{
	
			//订阅
			GameData.Score.SubscribeToText(score_Txt);

			GameData.Name.SubscribeToText(gameName_txt);

			//发送消息
			send_Btn.OnClickAsObservable().Subscribe(_ => {

				GameData.Name.Value = "游戏数据";

				GameData.Score.Value = 20;
			});


		}
	}

}
