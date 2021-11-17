using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace  LQFramework
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {

        private EditorMoudleContainer mContainer;
        //打开窗口
        //[MenuItem("LQFramework/LQUtils/0.EditorModulizationPlatform")]
        public static void Open()
        {

            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();
            editorPlatform.position=new Rect(
                Screen.width/2,
                Screen.height*2/3,
                600,500
                );
            
            editorPlatform.mContainer=new EditorMoudleContainer();

            editorPlatform.mContainer.Init();
            
            editorPlatform. Show();
        }


        private void OnGUI()
        {
            //渲染
             mContainer.ResolveAll<IEditorPlatformMoudle>()
                 .ForEach(e=>e.OnGUI());
        }
   
        
    }

    
}
