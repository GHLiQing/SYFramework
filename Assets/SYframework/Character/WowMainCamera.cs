using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace QFramework.LQ
{
	public class WowMainCamera : MonoBehaviour
	{
		//目标物体
		[Header("目标物体")]
		public Transform target;
		//目标物体的高度
		public float  targetHeight=0;
		//旋转速度
		public float xSpeed = 250.0f;

		public float ySpeed = 120.0f;
		//右键拖拽速度
		public float dragSpeed = 10;

		//左右y轴旋转限制
		public int yMinLimit = -90;

		public int yMaxLimit = 90;

		private float x;

		private float y;

		//是否允许控制
		[Header("是否允许控制 左键")]
		public bool allowControl;
		//是否允许拖拽
		[Header("是否允许拖拽 中间键")]
		public bool allowDrag;

		//是否允许拉近距离
		[Header("是否允许拉近距离")]
		public bool allowZoom;
		//当前距离
		[Header("当前摄像机与target 之间的距离  desiredDistance 配合使用")]

		[Header("摄像机与target初始距离")]
		public float desiredDistance;
		
		public float currentDistance;
		[Header("滑轮拉近距离速度")]
		public float zoomRotaSpeed=40;
		//限制拉近距离
		[Header("限制拉近距离 最小")]
		public float minDistance = -50;
		[Header("限制拉近距离 最大")]
		public float maxDistance = 50;
		//纠正位置
		private float correctedDistance;
		

		public float zoomDampening = 10.0f;
		[Header("是否允许摄像机初始化一些数据")]
		public bool AgreewithViewOnEnable = false;
		private void OnEnable()
		{
			if (AgreewithViewOnEnable)
			{
				AgreewithView();
			}
		}
		/// <summary>
		/// 初始一些数据 进行摄像机移动使用
		/// </summary>
		void AgreewithView()
		{
			bool temControll = allowControl;
			bool tempZoom = allowZoom;
			allowZoom = false;
			allowControl = false;
			x = transform.eulerAngles.x;
			y = transform.eulerAngles.y;
			Vector3 pos = new Vector3(transform.position.x, transform.position.y - targetHeight, transform.position.z);
			GameObject tempTarget = new GameObject();
			pos += transform.forward * desiredDistance;
			tempTarget.transform.position = pos;//设置初始位置
			Transform originTarget = target;
			target = tempTarget.transform;
			tempTarget.transform.DOMove(originTarget.position, 1f).OnComplete(() =>
			{
				target = originTarget;
				Destroy(tempTarget);
				allowZoom = tempTarget;
				allowControl = temControll;

			});

		}
		private void LateUpdate()
		{
			if (allowControl)
			{
				if (Input.GetMouseButton(0))
				{
					x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
					y += Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
				}
			}

			y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
			x = x % 360;
			y = y % 360;
			Quaternion rotation = Quaternion.Euler(-y, x, 0);
			
			//拖拽target 坐标中键
			if (allowDrag)
			{
				if (Input.GetMouseButton(2))
				{
					if (target!=null)
					{

						target.Translate(Input.GetAxis("Mouse X") * Time.deltaTime * dragSpeed, Input.GetAxis("Mouse Y") * Time.deltaTime * dragSpeed, 0, this.transform);
					}
				
				}
			}

			if (allowZoom)
			{
				desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRotaSpeed*20;
				
			}

			desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
			correctedDistance = desiredDistance;

			//计算所需摄像机位置
			//Debug.Log("target:" + target.position);
			//Debug.Log("rotation:" + rotation);
			//Debug.Log("desiredDistance:" + desiredDistance);
			//Debug.Log("targetHeight:" + targetHeight);
			//Debug.Log("rota:"+ rotation * Vector3.forward * desiredDistance);
			//Debug.Log("Vector3:" + (rotation * Vector3.forward * desiredDistance + new Vector3(0, -targetHeight, 0)));
			Vector3 position = target.position - (rotation * Vector3.forward * desiredDistance + new Vector3(0, -targetHeight, 0));
			//Debug.LogError("pos："+position);
			//如果有碰撞，纠正相机的位置，并计算修正的距离
			bool isCorrented = false;

			//为了平滑，lerp距离只有当任一距离没有被修正，或修正的距离大于当前距离
			
			currentDistance = !isCorrented || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * zoomDampening) : correctedDistance;
			//Debug.Log("currentDistance: " + currentDistance);
			//基于新的当前距离重新计算位置
			position = target.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -targetHeight - 0.05f, 0));

			//设置摄像机新的旋转
			transform.rotation = rotation;
			//设置摄像机新的位置
			transform.position = position;
		}

	}
}

