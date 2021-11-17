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
			TwoPanel,

		}

		private PageID currentSelect;
		private void OnGUI()
		{
			//ת��
			currentSelect = (PageID)GUILayout.Toolbar((int)currentSelect,Enum.GetNames(typeof(PageID)));

			if (currentSelect==PageID.BasePanel)
			{
				//
				Base();
			}
			else if (currentSelect == PageID.TwoPanel)
			{
				TwoPanel();
			}
		}

		#region Base

		
		private void Base()
		{

			GUILayout.BeginVertical();
			{
				GUILayout.Label("��ť");
				GUILayout.Button("Btn");
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
					userPassword = GUILayout.PasswordField(userPassword,'*');

				}
				GUILayout.EndHorizontal ();

				GUILayout.Label("toggle:");
				toggleGUI=GUILayout.Toggle(toggleGUI,"Toggle");

				GUILayout.Label("��������");
				hSlider = GUILayout.HorizontalSlider(0, 100, 0);
				GUILayout.Label("slider:" + hSlider);

				GUILayout.Space(100);
				//vSlider = GUILayout.VerticalSlider(0, 100, 0);
				//GUILayout.Label("slider:" + vSlider);
				GUILayout.Label("txtarea:");
				txtArea = GUILayout.TextArea(txtArea);

				
			}
			GUILayout.EndVertical();

		}
		#endregion

	}
}

