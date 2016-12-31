using UnityEngine;
using System;

namespace Terrapass.Extensions.Unity
{
	public static class Vector3Extensions
	{
		/// <summary>
		/// Returns the result of rotation of a point, specified by this Vector3 instance,
		/// around an axis, passing through another point, by a specified angle in degrees.
		/// </summary>
		/// <param name="vector3">Rotating point.</param>
		/// <param name="point">Point, through which the axis passes.</param>
		/// <param name="axis">Rotation axis.</param>
		/// <param name="angle">Angle in degrees.</param>
		public static Vector3 RotateAround(
			this Vector3 vector3,
			Vector3 point,
			Vector3 axis,
			float angle
		)
		{
			// TODO: This implementation is highly ineffective due to the creation/destruction
			// of an entire GameObject. This needs to be reimplemented mathematically.
			Transform transform = (new GameObject()).transform;
			transform.position = vector3;
			transform.RotateAround(point, axis, angle);
			Vector3 result = transform.position;
			GameObject.Destroy(transform.gameObject);
			return result;
		}

		/// <summary>
		/// Multiply this Vector3 by another one, element-by-element.
		/// </summary>
		/// <returns>Per-element multiplication result.</returns>
		/// <param name="vector3">This vector.</param>
		/// <param name="other">Another vector.</param>
		public static Vector3 TimesPerElement(
			this Vector3 vector3,
			Vector3 other
		)
		{
			return new Vector3(
				vector3.x * other.x,
				vector3.y * other.y,
				vector3.z * other.z
			);
		}
	}
}

