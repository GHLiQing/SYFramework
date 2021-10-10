using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LQFramework
{
    public class EditorMoudleContainer
    {
  
        /// <summary>
        /// 用来缓存的模块s
        /// </summary>
        private List<object> mInstances=new List<object>();


        /// <summary>
        /// 溶解 获取全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> ResolveAll<T>()
        {
            return mInstances.OfType<T>()
                .ToList();
        }

        public void Init()
        {
            //清空掉之前的实例
            mInstances.Clear();

            //1 获取当亲项目所有的assembly 可以理解为 dll
            // var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //2 获取编辑器环境 dll
            var editorAssembly = AssemblyUtil.EditorAssembly; //静态库收集
            
            //3  获取ieditorplatformMoudle 类型
            var moduleType = typeof(IEditorPlatformMoudle);

            mInstances = editorAssembly
                    //获取所有的编辑器环境中的类型
                .GetTypes()
                    //过滤掉抽象类型（接口/抽象类），和未实现 IeditorPlatformModule 的类型
                .Where(type => moduleType.IsAssignableFrom(type) && !type.IsAbstract)
              
                //获取类型的构造创建实例    
                .Select(type => type.GetConstructors().First().Invoke(null))
                .ToList();

        }
        
    }
}
