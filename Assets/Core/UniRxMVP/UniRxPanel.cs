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

			
				

			//����
			model.Score.SubscribeToText(score_Txt);

			model.Name.SubscribeToText(gameName_txt);

			//������Ϣ
			send_Btn.OnClickAsObservable().Subscribe(_ => {

				model.Name.Value = "��Ϸ����";

				model.Score.Value = Random.Range(1,100);
			});



		}
	}

}
