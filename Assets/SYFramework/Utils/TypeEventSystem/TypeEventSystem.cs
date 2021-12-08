using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
    public class TypeEventSystem
    {
        /// <summary>
        /// 接口 只负责存在字典中
        /// </summary>
     public interface IRegisterrations { }

        /// <summary>
        /// 多个注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
      public  class Registerations<T>:IRegisterrations
        {
            /// <summary>
            /// 不需要List<T>
            /// 因为委托就是一堆多
            /// </summary>
            public Action<T> OnReceives = obj => { };
        }


        public static Dictionary<Type, IRegisterrations> mTypeEventDic = new Dictionary<Type, IRegisterrations>();

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="onRecive"></param>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>(Action<T> onRecive)
        {
            var type = typeof(T);
            IRegisterrations registerrations = null;
            if (mTypeEventDic.TryGetValue(type,out registerrations))
            {
                var reg = registerrations as Registerations<T>;
                reg.OnReceives += onRecive;
            }
            else
            {
                var reg=new Registerations<T>();
                reg.OnReceives += onRecive;
                mTypeEventDic.Add(type,reg);
            }
        }

        /// <summary>
        /// 注销事件
        /// </summary>
        /// <param name="OnRecive"></param>
        /// <typeparam name="T"></typeparam>
        public static void UnRegister<T>(Action<T> OnRecive)
        {
            var type = typeof(T);
            IRegisterrations registerrations = null;
            if (mTypeEventDic.TryGetValue(type,out registerrations))
            {
                var reg = registerrations as Registerations<T>;
                reg.OnReceives -= OnRecive;
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void Send<T>(T t)
        {
            var type = typeof(T);
            IRegisterrations registerrations = null;
            if (mTypeEventDic.TryGetValue(type,out registerrations))
            {
                var reg = registerrations as Registerations<T>;
                reg.OnReceives(t);
            }
        }
        
        
    }
}

