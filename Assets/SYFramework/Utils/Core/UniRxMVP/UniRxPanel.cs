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



		public IModel model;
		private void Awake()
		{
			model = new GameData();

			
				

			//订阅
			model.Score.SubscribeToText(score_Txt);

			model.Name.SubscribeToText(gameName_txt);

			//发送消息
			send_Btn.OnClickAsObservable().Subscribe(_ => {

				model.Name.Value = "游戏数据";

				model.Score.Value = Random.Range(1,100);
			});



		}
	}

}
