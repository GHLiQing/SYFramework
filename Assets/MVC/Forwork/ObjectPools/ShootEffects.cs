using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffects : MonoBehaviour, TF_IReusable
{


	public float delyTime=1f;
	public float speed = 30f;
	private void Awake()
	{
		Invoke("OnSpawned", delyTime);
	}

	private void Update()
	{
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	public void OnSpawned()
	{
		//回收
		TF_ObjectPoolManager.Instance.UnSpawn(gameObject);
	}

	public void OnUpSpawned()
	{
		//取出对象
		Debug.Log("回收物体之后的回调");
		//TF_ObjectPoolManager.GetInstance.Spawn(gameObject);
	}
}
