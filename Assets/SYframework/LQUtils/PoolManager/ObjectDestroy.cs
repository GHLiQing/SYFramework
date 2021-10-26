using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework;
namespace LQFramework
{
	public class ObjectDestroy : MonoBehaviour, IReusable
	{

		public float delytime = 0.2f;
		public void OnSpawned()
		{
			this.Delay(delytime,()=>{

				//回收
				ObjectPoolManager.Instance.UnSpawn(gameObject);
			});
		}


		private void  Delay(float time, System.Action action)
		{
			StartCoroutine(IE_Delay(time,action));
		}

		IEnumerator IE_Delay(float time,System.Action action)
		{
			yield return new WaitForSeconds(time);
			action?.Invoke();
		}
		
		public void OnUpSpawned()
		{
			Debug.Log("回收了"+gameObject.name);
		}
	}

}
