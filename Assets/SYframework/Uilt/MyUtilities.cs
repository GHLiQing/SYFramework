using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QFramework.LQ
{
	public static class MyUtilities
	{
		#region Animation 扩展类 用于 动画Animation调用
		private static Dictionary<Animation, bool> bool_Animation = new Dictionary<Animation, bool>();
		/// <summary>
		/// Animation 扩展使用 
		/// </summary>
		/// <param name="ani"></param>
		/// <param name="AnimationName"></param>
		/// <param name="OnStart"></param>
		/// <param name="OnUpdate"></param>
		/// <param name="OnEnd"></param>
		public static void DetectionAnimation(this Animation ani,string AnimationName,UnityAction OnStart,UnityAction OnUpdate,UnityAction OnEnd)
		{
			if (!bool_Animation.ContainsKey(ani))
			{
				bool_Animation.Add(ani, false);

			}
			if (!bool_Animation[ani])
			{
				if (ani.IsPlaying(AnimationName))
				{
					bool_Animation[ani] = true;
					OnStart();
				}
			}
			else
			{
				if (ani.IsPlaying(AnimationName))
				{
					OnUpdate();
				}
				else
				{
					OnEnd();
					bool_Animation.Remove(ani);
				}
			}
		}
		/// <summary>
		/// 延时使用 animation 
		/// </summary>
		/// <param name="ani"></param>
		/// <param name="animationName"></param>
		/// <param name="OnStart"></param>
		/// <param name="OnUpdate"></param>
		/// <param name="OnEnd"></param>
		/// <returns></returns>
		public static IEnumerator IEDetectionAnimation(this Animation ani,string animationName,UnityAction OnStart,UnityAction OnUpdate,UnityAction OnEnd)
		{
			while (!ani.IsPlaying(animationName))
			{
				yield return null;
			}
			OnStart();
			while (ani.IsPlaying(animationName))
			{
				OnUpdate();
				yield return null;
			}
			OnEnd();
		}
		#endregion

		#region Animator 扩展使用 
		private static Dictionary<Animator, bool> bool_Animator = new Dictionary<Animator, bool>();
		/// <summary>
		/// animator 
		/// </summary>
		/// <param name="ani"></param>
		/// <param name="layerIndex"></param>
		/// <param name="stateName"></param>
		/// <param name="Onstart"></param>
		/// <param name="OnUpdate"></param>
		/// <param name="OnEnd"></param>
		public static void  DetectionAnimator(this Animator ani,int layerIndex,string stateName,UnityAction Onstart,UnityAction OnUpdate,UnityAction OnEnd)
		{
			//查找字典是否存在
			if (!bool_Animator.ContainsKey(ani))
			{
				bool_Animator.Add(ani, false);
			}
			//查找字典是否存在这个animator 
			if (!bool_Animator[ani])
			{
				//得到当前动画在那一层的动画信息
				if (ani.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
				{
					bool_Animator[ani] = true;
					Onstart();
				}
			}
			else
			{
				if (ani.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
				{
					OnUpdate();
				}
				else
				{
					bool_Animator[ani] = false;
					OnEnd();
				}
			}
		}

		public static IEnumerator IEDetectionAnimator(this Animator ani, int layerIndex, string stateName, UnityAction Onstart, UnityAction OnUpdate, UnityAction OnEnd)
		{
			while (!ani.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
			{
				yield return null;
			}
			Onstart();
			while (!ani.GetCurrentAnimatorStateInfo(layerIndex).IsName(stateName))
			{
				OnUpdate();
				yield return null;
			}
			OnEnd();

		}
		#endregion

		#region MonoBehaviour

		public static void DelayToDo(float timer,UnityAction method)
		{
			//float a = 0f;
			//DOTween.To(() => { return a; }, (v) => { a = v; }, 10, timer).OnComplete(() =>
			//{
			//	method();
			//});
		}
		#endregion
	}
}

