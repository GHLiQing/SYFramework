using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF_Destroy : MonoBehaviour,TF_IReusable
{

	public float delytime = 0.2f;

	public void OnSpawned()
	{
		//自动延时回收
		StartCoroutine(UnSpwan(delytime));
	}

	public void OnUpSpawned()
	{
		Debug.Log("物体回收"+gameObject.name);
	}
	IEnumerator  UnSpwan(float delyTime)
	{

		yield return new WaitForSeconds(delyTime);
		TF_ObjectPoolManager.Instance.UnSpawn(gameObject);//回收物体
		
	}
}
