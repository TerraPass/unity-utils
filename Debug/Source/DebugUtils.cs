using System;
using System.Diagnostics;

namespace Terrapass.Debug
{
	public static class DebugUtils
	{
		private const string ASSERTION_MESSAGE = "DEBUG ASSERTION FAILED: {0}";

		/// <summary>
		/// Check the specified condition. If assertion fails, the specified message
		/// will be printed to Unity Editor console and game mode will be paused.
		/// </summary>
		/// <remarks>
		/// Note that this method only works in Unity Editor. 
		/// All the calls to Assert() will be ignored in release builds.
		/// </remarks>
		/// <param name="condition">Condition to be checked. For assertion to pass it must be true.</param>
		/// <param name="format">Format of the message to print to Unity Editor console if condition is false.</param>
		/// <param name="args">Message format parameters.</param>
		[Conditional("UNITY_EDITOR")]
		public static void Assert(bool condition, string format, params object[] args)
		{
			if (!condition)
			{
				// LogError() method prints call stack together with error message.
				UnityEngine.Debug.LogError(
					String.Format(
						ASSERTION_MESSAGE,
						String.Format(
							format,
							args
						)
					)
				);
				UnityEngine.Debug.Break();
			}
		}
	}
}

