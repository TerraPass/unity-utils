using UnityEngine;
using System;

namespace Terrapass.Time
{
	public delegate void AlarmClockCallback(AlarmFiredEventArgs args);

	public interface ICallbackAlarmClock : IAlarmClock
	{
		AlarmClockCallback Callback {get;set;}
	}

	public static class ICallbackAlarmClockExtensions
	{
		public static void Reset(
			this ICallbackAlarmClock clock,
			AlarmClockCallback callback,
			float delay,
			bool startPaused = false
		)
		{
			clock.Callback = callback;
			clock.Delay = delay;
			clock.Reset(startPaused);
		}

		public static void Reset(
			this ICallbackAlarmClock clock,
			AlarmClockCallback callback,
			bool startPaused = false
		)
		{
			clock.Reset(callback, clock.Delay, startPaused);
		}
	}
}

