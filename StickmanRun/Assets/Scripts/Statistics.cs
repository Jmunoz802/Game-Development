/*  
 * File: Statistics.cs 
 * Version: 1.0.1
 * Desc:	Singleton class that handles time keeping for score and time survived
 */

using UnityEngine;
using System.Collections;

public class Statistics{

	private static Statistics instance;

	private float StartTime;
	private float RoundTime;
	private float PauseTime;
	private float PlatformCount;

	private float maxTime;
	private float maxPlCount;

	public static Statistics Instance
	{
		get{
			if(instance == null)
				instance = new Statistics();

			return instance;
		}
	}

	private Statistics()
	{}

	public void loadStats()
	{
		if(PlayerPrefs.HasKey("MAXTIME"))
		{
			maxTime = PlayerPrefs.GetFloat("MAXTIME");
		}
		if(PlayerPrefs.HasKey("MAXPL"))
		{
			maxPlCount = PlayerPrefs.GetFloat("MAXPL");
		}
	}

	public void saveStats()
	{
		PlayerPrefs.SetFloat("MAXTIME", maxTime);
		PlayerPrefs.SetFloat("MAXPL", maxPlCount);
	}

	public void clearStats()
	{
		PlayerPrefs.SetFloat("MAXTIME", 0f);
		PlayerPrefs.SetFloat("MAXPL", 0f);
	}

	public void startTime()
	{
		StartTime = Time.time;
	}

	public void endTime()
	{
		RoundTime = Time.time - StartTime;
		maxTime = Mathf.Max(RoundTime, maxTime);
	}

	public void pauseTime()
	{
		PauseTime = Time.time;
	}

	public void unpauseTime()
	{
		StartTime += (Time.time - PauseTime);
	}

	public bool newMaxTime()
	{
		return RoundTime==maxTime;
	}

	~Statistics(){
		saveStats();
		PlayerPrefs.Save();
	}

}
