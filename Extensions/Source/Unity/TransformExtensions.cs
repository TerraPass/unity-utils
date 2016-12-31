using UnityEngine;
using System;

namespace Terrapass.Extensions.Unity
{
	public static class TransformExtensions
	{
		/// <summary>
		/// Interpolates between current state of this transform and target transform,
		/// applies resulting state to this transform.
		/// </summary>
		/// <param name="transform">This transform.</param>
		/// <param name="targetTransform">Target transform.</param>
		/// <param name="lerpAmount">Interpolation amount.</param>
		public static void LerpTo(
			this Transform transform,
			Transform targetTransform,
			float lerpAmount
		)
		{
			transform.LerpTo(
				targetTransform.position,
				targetTransform.rotation,
				targetTransform.localScale,
				lerpAmount
			);
		}

		/// <summary>
		/// Interpolates between current position of this transform and target position,
		/// applies resulting value as position of this transform.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="targetPosition">Target position.</param>
		/// <param name="lerpAmount">Interpolation amount.</param>
		public static void LerpTo(
			this Transform transform,
			Vector3 targetPosition,
			float lerpAmount
		)
		{
			transform.position = Vector3.Lerp(
				transform.position,
				targetPosition,
				lerpAmount
			);
		}

		/// <summary>
		/// Interpolates between current state of this transform and target position, rotation and scale,
		/// applies resulting state to this transform.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="targetPosition">Target position.</param>
		/// <param name="targetRotation">Target rotation.</param>
		/// <param name="targetScale">Target scale.</param>
		/// <param name="lerpAmount">Interpolation amount.</param>
		public static void LerpTo(
			this Transform transform,
			Vector3 targetPosition,
			Quaternion targetRotation,
			Vector3 targetScale,
			float lerpAmount
		)
		{
			transform.LerpTo(targetPosition, lerpAmount);
			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				targetRotation,
				lerpAmount
			);
			transform.localScale = Vector3.Lerp(
				transform.localScale,
				targetScale,
				lerpAmount
			);
		}
	}
}

