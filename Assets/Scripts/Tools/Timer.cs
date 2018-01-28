using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{
	protected float duration;
	protected Action callback;
	protected float interval;
	protected int repeat;
	protected GameObject go;
	public bool IsFinished
	{
		get { return duration <= 0 ? true : false; }
	}

	public Timer (float duration, GameObject go, Action callback, float interval = 0, int repeat = 0)
	{
		this.duration = duration;
		this.callback = callback;
		this.interval = interval;
		this.repeat = repeat;
		this.go = go;
	}

	public void Tick (float delta)
	{
		
		if (go == null)
		{
			TimerManager.Instance.RemoveTimer(this);
			return;
		}
		duration -= delta;
		if (duration <= 0)
		{
			callback();
			if (repeat > 0)
			{
				repeat--;
				duration += interval;
			}
		}
	}
}