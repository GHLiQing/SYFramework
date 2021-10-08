using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Task/BulletConfige")]
public class BulletConfig:ScriptableObject
{
	public float G_MoveSpeed = 10;

	public float NoG_MoveSpeed = 50;
	public bool IsGravity = true;
}
