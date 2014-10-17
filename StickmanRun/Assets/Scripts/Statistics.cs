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
	private float maxTime;

	private int PlatformCount;
	private int maxPlCount;

	public static Statistics Instance
	{
		get{
			if(instance == null)
				instance = new Statistics();

			return instance;
		}
	}

	private Statistics()
	{
		StartTime = 0f;
		RoundTime = 0f;
		PauseTime = 0f;
		PlatformCount = 0;
		maxTime = 0f;
		maxPlCount = 0;
	}

	public void loadStats()
	{
		if(PlayerPrefs.HasKey("MAXTIME"))
		{
			maxTime = PlayerPrefs.GetFloat("MAXTIME");
		}
		if(PlayerPrefs.HasKey("MAXPL"))
		{
			maxPlCount = PlayerPrefs.GetInt("MAXPL");
		}
	}

	public void saveStats()
	{
		PlayerPrefs.SetFloat("MAXTIME", maxTime);
		PlayerPrefs.SetInt("MAXPL", maxPlCount);
	}

	public void clearStats()
	{
		PlayerPrefs.SetFloat("MAXTIME", 0f);
		PlayerPrefs.SetInt("MAXPL", 0);
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

	public string printTime()
	{
		int min = Mathf.RoundToInt(RoundTime)/60;
		int sec = Mathf.RoundToInt(RoundTime)%60;

		string seconds = sec.ToString();
		if(sec < 10)
			seconds = string.Concat("0", seconds);

		if(min == 0)
			return seconds + " seconds!";
		else
			return min.ToString() + " minutes and " + seconds + " seconds!";
	}

	~Statistics(){
		saveStats();
		PlayerPrefs.Save();
	}

}
