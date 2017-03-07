using UnityEngine;
using System;

namespace Terrapass.Time
{
	public interface ITimeIntervalFormatter
	{
		string Format(float seconds);
	}
}

