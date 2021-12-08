using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


namespace  SYFramework
{
    public class TestMoudle : IEditorPlatformMoudle
    {
        public void OnGUI()
        {

            GUILayout.Label("这是我的第一个模块", new GUIStyle()
                {
                    fontSize = 30
                }
            );

        }
    }

}
