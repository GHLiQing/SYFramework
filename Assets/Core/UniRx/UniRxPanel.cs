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
	
			//����
			GameData.Score.SubscribeToText(score_Txt);

			GameData.Name.SubscribeToText(gameName_txt);

			//������Ϣ
			send_Btn.OnClickAsObservable().Subscribe(_ => {

				GameData.Name.Value = "��Ϸ����";

				GameData.Score.Value = 20;
			});


		}
	}

}
