using UnityEngine;
using System;

namespace Terrapass.Time
{
	public partial class AlarmClock : IAlarmClock
	{
		private struct Alarm
		{
			public readonly float time;
			public readonly AlarmClock clock;

			public Alarm(float time, AlarmClock clock)
			{
				this.time = time;
				this.clock = clock;
			}
		}

		private readonly ResettableExecutionTimer timerImpl;

		private float delay;
		private Alarm? currentAlarm;

		public AlarmClock(float delay, bool startPaused = false)
		{
			this.timerImpl = new ResettableExecutionTimer(startPaused);
			this.Delay = delay;
		}

		#region IAlarmClock implementation

		public event EventHandler<AlarmFiredEventArgs> AlarmFired;

		public float RemainingSeconds
		{
			get {
				return this.Delay - this.ElapsedSeconds;
			}
		}

		public float Delay {
			get {
				return this.delay;
			}
			set {
				if(!this.IsPaused)
				{
					this.DeleteCurrentAlarm();
				}
				this.delay = value;
				if(!this.IsPaused)
				{
					this.SetupCurrentAlarm();
				}
			}
		}

		#endregion

		public bool Resume()
		{
			var result = this.timerImpl.Resume();
			if(result)
			{
				this.SetupCurrentAlarm();
			}
			return result;
		}

		public bool Pause()
		{
			var result = this.timerImpl.Pause();
			if(result)
			{
				this.DeleteCurrentAlarm();
			}
			return result;
		}

		public void Reset(bool startPaused)
		{
			if(!this.IsPaused)
			{
				this.DeleteCurrentAlarm();
			}

			this.timerImpl.Reset(startPaused);

			if(!startPaused)
			{
				this.SetupCurrentAlarm();
			}

		}

		public float ElapsedSeconds
		{
			get {
				return this.timerImpl.ElapsedSeconds;
			}
		}

		public bool IsPaused
		{
			get {
				return this.timerImpl.IsPaused;
			}
		}

		private static float CurrentTime
		{
			get {
				return UnityEngine.Time.unscaledTime;
			}
		}

		private void DeleteCurrentAlarm()
		{
			if(this.currentAlarm != null)
			{
				AlarmClockHelper.Instance.DeleteAlarm(this.currentAlarm.Value);
				this.currentAlarm = null;
			}
		}

		private void SetupCurrentAlarm()
		{
			var alarm = new Alarm(
				CurrentTime + this.RemainingSeconds,
				this
			);
			AlarmClockHelper.Instance.AddAlarm(alarm);
			this.currentAlarm = alarm;
		}

		private void OnAlarmClockFired()
		{
			this.DeleteCurrentAlarm();
			this.AlarmFired(
				this,
				new AlarmFiredEventArgs(this)
			);
		}
	}
}

