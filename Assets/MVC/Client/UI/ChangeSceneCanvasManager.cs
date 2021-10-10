using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSceneCanvasManager : MonoBehaviour
{
	private Slider mProgressSlider;
	private Text mTxt;
	private void Awake()
	{
		mProgressSlider = transform.Find("ProgressSlider").GetComponent<Slider>();
		mTxt = transform.Find("ProgressSlider/Handle Slide Area/Text").GetComponent<Text>();


	}
	private void Start()
	{
		StartCoroutine(TF_SceneManager.Instance.LoadScene());
	}
	private void Update()
	{
		mProgressSlider.value = TF_SceneManager.Instance.Progress;
		mTxt.text = ((int)(mProgressSlider.value * 100)).ToString() + "%";


	}
}
