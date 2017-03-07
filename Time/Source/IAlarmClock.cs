using UnityEngine;
using System;

namespace Terrapass.Time
{
	public interface IAlarmClock : IResettableTimer
	{
		float RemainingSeconds {get;}
		float Delay {get;set;}

		event EventHandler<AlarmFiredEventArgs> AlarmFired;
	}

	public static class IAlarmClockExtensions
	{
		public static void Reset(this IAlarmClock alarmClock, float delay, bool startPaused = false)
		{
			alarmClock.Delay = delay;
			alarmClock.Reset(startPaused);
		}
	}
}

