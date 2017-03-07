using UnityEngine;
using System;

namespace Terrapass.Time
{
	public class MinutesSecondsFormatter : ITimeIntervalFormatter
	{
		#region ITimeIntervalFormatter implementation

		/// <summary>
		/// Create a string from specified number of seconds as mm:ss.
		/// E.g. 94 seconds will become "01:34".
		/// </summary>
		/// <returns>String corresponding to specified number of seconds as mm:ss.</returns>
		/// <param name="seconds">Seconds.</param>
		public string Format(float seconds)
		{
			int minutes = (int)seconds / 60;
			int leftoverSeconds = (int)seconds % 60;
			return (minutes < 10 ? "0" : "") + minutes.ToString() + ":"
				+ (leftoverSeconds < 10 ? "0" : "") + leftoverSeconds.ToString();
		}

		#endregion
	}
}

