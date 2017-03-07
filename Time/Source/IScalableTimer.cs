using System;

namespace Terrapass.Time
{
	public interface IScalableTimer : ITimer
	{
		float Scale {get;set;}
	}
}

