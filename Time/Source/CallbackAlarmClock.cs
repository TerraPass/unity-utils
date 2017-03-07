using UnityEngine;
using System;
using Terrapass.Debug;

namespace Terrapass.Time
{
	public class CallbackAlarmClock : AlarmClock, ICallbackAlarmClock
	{
		private AlarmClockCallback callback;

		public CallbackAlarmClock(
			AlarmClockCallback callback,
			float delay,
			bool startPaused = false
		) : base(delay, startPaused)
		{
			if(callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			this.Callback = callback;
			base.AlarmFired += this.OnBaseAlarmFired;
		}

		public AlarmClockCallback Callback
		{
			get {
				return this.callback;
			}
			set {
				this.callback = value;
			}
		}

		private void OnBaseAlarmFired(object sender, AlarmFiredEventArgs args)
		{
			this.callback(args);
		}
	}
}

