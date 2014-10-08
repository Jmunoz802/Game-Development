using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float maxY;
	public float minY;
	public float smoothing = 5f;
	
	private GameObject mainplayer;
	private bool[] limit;
	private bool direction;

	void Awake()
	{
		limit = new bool[2];

		GameObject[] screenref = GameObject.FindGameObjectsWithTag("Reference");
		if(screenref[0].name.CompareTo("ScreenBottom") ==0)
		{
			minY = screenref[0].transform.position.y;
			maxY = screenref[1].transform.position.y;
		}
		else
		{
			maxY = screenref[0].transform.position.y;
			minY = screenref[1].transform.position.y;
		}
	}

	// Use this for initialization
	void Start () {
		mainplayer = GameObject.FindGameObjectWithTag("Player");


		
		//limit = new bool[2];
		direction = true; //true up
	}
	
	// Update is called once per frame
	void Update () {

		checkLimit();

		direction = charDistance() > 0.2f;
		float testy;
		if(direction)
			testy = Mathf.Log( (mainplayer.transform.position.y - transform.position.y) + 1) + 0.25f;
		else
			testy = -Mathf.Log( (transform.position.y - mainplayer.transform.position.y) + 1 ) + 0.25f;
		//Debug.LogWarning("testy: " + testy + ". limit: " + atLimit() + ". charDist: " + charDistance());
		Vector3 trans = new Vector3(0, testy);

		transform.Translate(trans);


		Vector3 cl = transform.position;
		cl.y = Mathf.Clamp(cl.y, minY + 5, maxY - 4);
		transform.position = cl;

	}

	float charDistance()
	{
		return mainplayer.transform.position.y - transform.position.y;
	}

	void checkLimit()
	{
		limit[0] = charDistance() >= maxY -4f;
		limit[1] = charDistance() <= minY +5f;
	}

	bool atLimit()
	{
		return  limit[0] || limit[1];
	}

}
