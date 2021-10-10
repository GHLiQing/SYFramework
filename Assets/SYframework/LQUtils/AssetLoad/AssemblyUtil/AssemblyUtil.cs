using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using  UnityEditor;
namespace LQFramework
{
    public class AssemblyUtil
    {
        public static Assembly  EditorAssembly
        {
            get
            {
                //1 获取当前项目中所有assembly 可以以理未代码编辑好的dll
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                //2 获取编辑器环境 dll
                var editorAssembly = assemblies.First(a => a.FullName.StartsWith("Assembly-Caharp-Editor"));

                return editorAssembly;
            }
        }
    }

}
