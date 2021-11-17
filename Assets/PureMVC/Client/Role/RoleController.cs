using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SYFramework;
/// <summary>
/// 遥感控制ui
/// </summary>
public class RoleController : MonoSingleton<RoleController>
{
	private float border = 500f;
	private float radir = 125f;//半径

	private RectTransform mJoyStick_Arrow;//移动的按钮
	private RectTransform mJoystick;//遥感

	private bool mIsmove = false;
	[SerializeField]
	private bool mIsDynamic = false;

	private void Awake()
	{
		mJoyStick_Arrow = transform.Find("").GetComponent<RectTransform>();
	}
	private void Start()
	{
		if (mIsDynamic)
		{
			mJoystick.gameObject.SetActive(false);
		}
	}
	private void Update()
	{
		//开启遥感
		if (Input.GetMouseButtonDown(0))
		{
			BeginJoyStick();
		}
		if (mIsmove)
		{
			DoingJoyStick();
		}
		//结束遥感
		if (Input.GetMouseButtonUp(0)&& mIsmove)
		{
			EndJoyStick();
		}
	}

	private void BeginJoyStick()
	{
		if (Input.mousePosition.x < border && Input.mousePosition.y < border)
		{
			if (mIsDynamic)
			{
				mJoystick.gameObject.SetActive(true);
			}
			mIsmove = true;
		}
	}

	private void EndJoyStick()
	{
		mIsmove = false;
		if (mIsDynamic)
		{
			mJoystick.gameObject.SetActive(false);
		}
		mJoyStick_Arrow.localPosition = Vector3.zero;
	}

	private void DoingJoyStick()
	{
		mJoyStick_Arrow.position = Input.mousePosition;
		//限制在这个范围内
		if (Vector2.Distance(mJoyStick_Arrow.anchoredPosition, Vector2.zero) > radir)
		{
			mJoyStick_Arrow.anchoredPosition = mJoyStick_Arrow.anchoredPosition.normalized * radir;
		}

	}
}
