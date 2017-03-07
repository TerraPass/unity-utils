using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Terrapass.Extensions.Unity;
using Terrapass.Debug;

using Terrapass.Collections;

namespace Terrapass.Time
{
	public partial class AlarmClock
	{
		private class AlarmComparer : IComparer<Alarm>
		{
			public int Compare(Alarm a, Alarm b)
			{
				return a.time.CompareTo(b.time);
			}
		}
		
		private class AlarmClockHelper : MonoBehaviour
		{
			private const string GAMEOBJECT_NAME = "AlarmClockHelper";
			
			private static AlarmClockHelper instance;
			
			public static AlarmClockHelper Instance
			{
				get {
					if(instance == null)
					{
						instance = (new GameObject(GAMEOBJECT_NAME)).AddComponent(typeof(AlarmClockHelper)) as AlarmClockHelper;
						instance.PerformInitialization();
					}
					return instance;
				}
			}
			
			private IPriorityQueue<Alarm> alarms;
			
			void PerformInitialization()
			{
				DontDestroyOnLoad(this.gameObject);
				
				this.alarms = new SortedListBasedPriorityQueue<Alarm>(new AlarmComparer());
			}
			
			void Update()
			{
				while(this.alarms.Count > 0 && this.alarms.Front.time <= CurrentTime)
				{
					this.alarms.PopFront().clock.OnAlarmClockFired();
				}
			}
			
			private static float CurrentTime
			{
				get {
					return AlarmClock.CurrentTime;
				}
			}
			
			public void AddAlarm(Alarm alarm)
			{
				this.alarms.Add(alarm);
			}
			
			public bool DeleteAlarm(Alarm alarm)
			{
				return this.alarms.Remove(alarm);
			}
		}
	}
}

