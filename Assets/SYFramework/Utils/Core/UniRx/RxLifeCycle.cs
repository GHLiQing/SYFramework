using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{
	public class RxLifeCycle : MonoBehaviour
	{
		private void Awake()
		{
			Observable.EveryUpdate().
				Where(_=>Input.GetMouseButtonDown(0)) //�൱��if �ж�
				.First() //ִֻ��һ��  Subscribe�����ĵ��¼����߻ص�
				.Subscribe(_ => {
				Debug.Log("���ֻ�ܵ��һ��");

			}).AddTo(this); 

			
		}
	}

}
