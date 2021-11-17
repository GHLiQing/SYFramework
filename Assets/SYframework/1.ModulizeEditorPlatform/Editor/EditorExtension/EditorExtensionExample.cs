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

		[MenuItem("EditorExtension/1.0 �༭����չ���׿��")]
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
			
			//ת��
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
			colorbool = GUILayout.Toggle(colorbool,"�ı���ɫ");
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
			scaleBool=GUILayout.Toggle(scaleBool, "����");
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
			rotaPanelbool = GUILayout.Toggle(rotaPanelbool, "��ת");
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
			pageEnable = GUILayout.Toggle(pageEnable, "�Ƿ񽻻��ڶ������");

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
				GUILayout.Label("��ť");
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
					GUILayout.Label("�����û�����");
					userName = GUILayout.TextField(userName);

				}
				GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("�������룺");
					userPassword = GUILayout.PasswordField(userPassword, '*');

				}
				GUILayout.EndHorizontal();

				GUILayout.Label("toggle:");

				toggleGUI = GUILayout.Toggle(toggleGUI, "Toggle");

				GUILayout.Label("��������");
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
					
					if (GUILayout.Button("��ť"))
					{
						Debug.Log("���");
					}
				}
				GUILayout.EndHorizontal();
				
			


			}
			GUILayout.EndVertical();

		}
		#endregion

	}
}

