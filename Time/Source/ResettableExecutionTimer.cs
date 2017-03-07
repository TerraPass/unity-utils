using System;

namespace Terrapass.Time
{
	public class ResettableExecutionTimer : ExecutionTimer, IResettableTimer
	{
		public ResettableExecutionTimer() : base() {}
		public ResettableExecutionTimer(bool startPaused) : base(startPaused) {}

		#region IResettableTimer implementation

		public void Reset (bool startPaused = true)
		{
			this.AccumulatedTime = 0;
			this.StartTime = CurrentTime;
			this.IsPaused = startPaused;
		}

		#endregion
	}
}

