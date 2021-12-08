using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document
{

	//显示
	public void DisPlay()
	{
		Debug.Log("显示");
	}

	public void Undo()
	{
		Debug.Log("撤销");
	}

	public void Redo()
	{
		Debug.Log("重做");
	}
}
