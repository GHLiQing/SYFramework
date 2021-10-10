using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InpuManager : MonoBehaviour
{
	public const int moveArrowRediu = 200;

	public const int border = 500;

	private RectTransform arrow;

	bool isMove=false;
	private void Awake()
	{
		arrow = transform.Find("Arrom").GetComponent<RectTransform>();
	}

	private void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			if (Input.mousePosition.x<border&& Input.mousePosition.y<border)
			{
				isMove = true;
			}
		}

		if (isMove)//移动
		{
			arrow.position = Input.mousePosition;
			if (Vector2.Distance(arrow.anchoredPosition,Vector2.zero)>moveArrowRediu)
			{
				arrow.anchoredPosition = arrow.anchoredPosition.normalized * moveArrowRediu;
			}
		}
		if (Input.GetMouseButtonUp(0)) //还原
		{
			arrow.localPosition = Vector3.zero;
			isMove = false;
		}
	}
}
