using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.GameManagement
{
	public class GameManager : Singleton<GameManager>
	{
		private Camera _mainCamera = null;
		public Camera MainCamera => GetMainCamera();

		private Camera GetMainCamera()
		{
			if(_mainCamera == null)
				_mainCamera = Camera.main;

			return _mainCamera;
		}
	}
}