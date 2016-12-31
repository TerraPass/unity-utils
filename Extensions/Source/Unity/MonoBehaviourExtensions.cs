using UnityEngine;
using System;
using System.Diagnostics;
using Terrapass.Debug;

namespace Terrapass.Extensions.Unity
{
	public static class MonoBehaviourExtensions
	{
		/// <summary>
		/// This method ensures that all the fields of a MonoBehaviour, 
		/// which have a <see cref="SerializeField"/> attribute, are set to a non-null value.
		/// If this is not the case, a debug assertiong failure is triggered.
		/// </summary>
		/// <remarks>
		/// Note that this method only works in Unity Editor. 
		/// All the calls to EnsureRequiredFieldsAreSetInEditor() will be ignored in release builds.
		/// </remarks>
		/// <param name="monoBehaviour">a MonoBehaviour instance.</param>
		[Conditional("UNITY_EDITOR")]
		public static void EnsureRequiredFieldsAreSetInEditor(this MonoBehaviour monoBehaviour)
		{
			var fields = monoBehaviour.GetType().GetFields(
				System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic
			);
			foreach(var field in fields)
			{
				DebugUtils.Assert(
					!(Attribute.IsDefined(field, typeof(SerializeField))) || field.GetValue(monoBehaviour) != null,
						String.Format(
						"{0} has null as value for required field {1}",
						monoBehaviour.GetType().ToString(),
						field.Name
					)
				);
			}
		}
	}
}

