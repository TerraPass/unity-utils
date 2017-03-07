using UnityEngine;
using System;
using Terrapass.Debug;

namespace Terrapass.Time
{
	public enum TimePrecision
	{
		SECONDS 		= 0,
		MILLISECONDS 	= -3,
		MICROSECONDS 	= -6,
		NANOSECONDS 	= -9
	}

	public static class TimePrecisionExtensions
	{
		public static int GetPowerOf10(this TimePrecision precision)
		{
			return (int)precision;
		}

		public static int GetMultiplier(this TimePrecision precision)
		{
			return (int)Mathf.Pow(10, precision.GetPowerOf10());
		}

		public static String GetAbbreviation(this TimePrecision precision)
		{
			switch(precision)
			{
			default:
				DebugUtils.Assert(
					false, 
					String.Format(
						"Abbreviation requested for unknown TimePrecision value {0}",
						precision.ToString()
					)
				);
				return null;

			case TimePrecision.SECONDS: 		return "s";
			case TimePrecision.MILLISECONDS: 	return "ms";
			case TimePrecision.MICROSECONDS: 	return "us";
			case TimePrecision.NANOSECONDS: 	return "ns";
			}
		}
	}
}

