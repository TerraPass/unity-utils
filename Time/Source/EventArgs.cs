using UnityEngine;
using System;

namespace Terrapass.Time
{
	public class AlarmFiredEventArgs : EventArgs
	{
		private readonly IAlarmClock alarmClock;

		public AlarmFiredEventArgs(IAlarmClock alarmClock)
		{
			this.alarmClock = alarmClock;
		}

		public IAlarmClock AlarmClock
		{
			get {
				return this.alarmClock;
			}
		}
	}
}

