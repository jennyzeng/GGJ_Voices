using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimerManager : SingletonBase<TimerManager>
{
	public List<Timer> CurrentTimers;// = new List<Timer>();
		
	protected override void Init(){
		transform.SetParent(GameManager.Instance.transform);
		CurrentTimers = new List<Timer>();
	}
	void FixedUpdate ()
	{
		//if (Game.isPaused)
		//    return;

		foreach (Timer timer in Instance.CurrentTimers.ToArray())
		{
			timer.Tick(Time.deltaTime);
			if (timer.IsFinished)
			{
				Instance.CurrentTimers.Remove(timer);
			}
		}

	}

	public void AddTimer(float duration, GameObject go, Action callback,
						 float interval = 0, int repeat = 0)
	{
		Instance.CurrentTimers.Add(new Timer(duration, go, callback, interval, repeat));
	}
	public void AddTimer (Timer timer)
	{
		Instance.CurrentTimers.Add(timer);
	}

	public void RemoveTimer(Timer timer)
	{
		Instance.CurrentTimers.Remove(timer);
	}
}