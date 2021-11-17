using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;

namespace SYFramework
{
	public class EditorExtensionExample : EditorWindow
	{

		[MenuItem("EditorExtension/1.0 编辑器扩展简易框架")]
		static void Open()
		{
			GetWindow<EditorExtensionExample>().Show();
		}


		enum PageID
		{
			BasePanel,
			EnablePanel,
			RotaPanel,
			Scale,
			Color,
			TwoPanel,

		}

		private PageID currentSelect;

		private bool pageEnable=true;
		private void OnGUI()
		{
			
			//转换
			currentSelect = (PageID)GUILayout.Toolbar((int)currentSelect,Enum.GetNames(typeof(PageID)));

			if (currentSelect==PageID.BasePanel)
			{
				//
				Base();
			}
			else if (currentSelect == PageID.EnablePanel)
			{
				Enable();
			}
			else if (currentSelect==PageID.RotaPanel)
			{
				RotaPanel();

			}
			else if (currentSelect == PageID.Scale)
			{
				Scale();
			}
			else if (currentSelect == PageID.Color)
			{
				ChangeColor();
			}
			else if (currentSelect == PageID.TwoPanel)
			{
				TwoPanel();
			}
		}

		#region Color
		private bool colorbool;

		private void ChangeColor()
		{
			colorbool = GUILayout.Toggle(colorbool,"改变颜色");
			if (colorbool)
			{
				GUI.color = Color.green;
			}
			TwoPanel();
		}
		#endregion

		#region Scale
		private bool scaleBool;

		private void Scale()
		{
			scaleBool=GUILayout.Toggle(scaleBool, "缩放");
			if (scaleBool)
			{
				GUIUtility.ScaleAroundPivot(Vector2.one*0.1f, Vector2.one*200f);
			}

			TwoPanel();
		}

		#endregion

		#region Rota

		private bool rotaPanelbool;
		private void RotaPanel()
		{
			rotaPanelbool = GUILayout.Toggle(rotaPanelbool, "旋转");
			if (rotaPanelbool)
			{
				GUIUtility.RotateAroundPivot(45, Vector2.one);
			}
			Base();

		}
		#endregion


		#region Enable
		private void Enable()
		{
			pageEnable = GUILayout.Toggle(pageEnable, "是否交互第二个面板");

			if (GUI.enabled!=pageEnable)
			{
				GUI.enabled = pageEnable;
			}
		
			Base();
		}

		#endregion

		#region Base


		private void Base()
		{

			GUILayout.BeginVertical();
			{
				GUILayout.Label("按钮");
				GUILayout.Button("Btn");

				GUILayout.Box("Box",new GUIStyle() { fixedHeight=100,fixedWidth=200});

			}
			GUILayout.EndVertical();
			
		}
		#endregion


		#region TwoPanel

		private string userName;

		private string userPassword=string.Empty;

		private bool toggleGUI = false;

		private float hSlider = 0;

		private float vSlider = 0;

		private string txtArea = "";
		private void TwoPanel()
		{
			GUILayout.Box("Box");

			GUILayout.BeginVertical();
			{
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("输入用户名：");
					userName = GUILayout.TextField(userName);

				}
				GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("输入密码：");
					userPassword = GUILayout.PasswordField(userPassword, '*');

				}
				GUILayout.EndHorizontal();

				GUILayout.Label("toggle:");

				toggleGUI = GUILayout.Toggle(toggleGUI, "Toggle");

				GUILayout.Label("滑动条：");
				hSlider = GUILayout.HorizontalSlider(0, 100, 0);
				GUILayout.Label("slider:" + hSlider);

				GUILayout.Space(100);
				//vSlider = GUILayout.VerticalSlider(0, 100, 0);
				//GUILayout.Label("slider:" + vSlider);
				GUILayout.Label("txtarea:");
				txtArea = GUILayout.TextArea(txtArea);

				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("Button:");
					
					if (GUILayout.Button("按钮"))
					{
						Debug.Log("点击");
					}
				}
				GUILayout.EndHorizontal();
				
			


			}
			GUILayout.EndVertical();

		}
		#endregion

	}
}

