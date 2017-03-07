using System;

namespace Terrapass.Time
{
	public interface IResettableTimer : ITimer
	{
		void Reset(bool startPaused = true);
	}	
}

