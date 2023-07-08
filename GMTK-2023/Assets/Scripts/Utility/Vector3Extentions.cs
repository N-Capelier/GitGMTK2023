using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extentions
{
	public static Vector3 SetX(this Vector3 v, float x)
	{
		return new Vector3(x, v.y, v.z);
	}
}