using System.Collections;
using System.Collections.Generic;
using Runtime.GameManagement;
using UnityEngine;

namespace Runtime.Rendering
{
    public class FaceCameraNormal : MonoBehaviour
    {
		private const float ROTATION_OFFSET = 5f;

		private Camera _mainCamera = null;

		private void Update()
		{
			if (_mainCamera == null)
				_mainCamera = GameManager.Instance.MainCamera;

			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.SetX(-_mainCamera.transform.rotation.eulerAngles.x - ROTATION_OFFSET));
		}
	}
}