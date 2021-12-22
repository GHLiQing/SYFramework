using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class ModelAndViewTest : MonoBehaviour
	{
		private void Awake()
		{
			var model = new Model();

			var view = new View("View");

			model.Subscribe(view);

			model.UpdataLevel(2);

			model.QuitGame();
		}
	}
}

