using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public bool activeSpawn;
	public bool activePlatforms;

	public float platformSpeed;
	public float maxPlatformSpeed = 0.09f;
	public float timeToMax = 120f;

	public float minXDistance = 2f;
	public float maxXDistance = 4.5f;

	public float minYDistance = -5f;
	public float maxYDistance = 3.23f;

	public float maxTop;
	public float minBottom;

	private float platformID;

	private Queue platforms;
	private GameObject recentPlatform;
	private GameObject spawnLocation;
	private string prefabPath = "Prefabs/";

	private Transform platPrefab;

	public float PlatformSpeed{
		get{
			return platformSpeed;
		}
		set{
			platformSpeed = value;
		}
	}

	private void Awake()
	{
		platPrefab = Resources.Load(prefabPath + "platform", typeof(Transform)) as Transform;
		spawnLocation = GameObject.Find("Spawn");

		GameObject[] startplatforms = GameObject.FindGameObjectsWithTag("Platform");
		recentPlatform = startplatforms[0];
		foreach(GameObject plat in startplatforms){
			if(recentPlatform.transform.position.x < plat.transform.position.x)
			{
				recentPlatform = plat;
			}
		}
		if(startplatforms.Length != 0)
		{
			platformID = startplatforms.Length;
		}
		else
		{
			Debug.Log("PlatformScript: There are no platforms at start of scene");
			platformID = 1;
		}

	}

	// Use this for initialization
	void Start () {
		Transform top = transform.FindChild("ScreenTop");
		Transform bot = transform.FindChild("ScreenBottom");
		maxTop = top.position.y;
		minBottom = bot.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.childCount == 0)
		{
			activePlatforms = false;
		}

		if(activePlatforms)
		{
			//Transform Platforms = GameObject.Find("Platforms").transform;;
			Transform platform;
			//if(Platforms == null)
			//	Debug.LogError("platfroms returns null");
			for(int i = 0; i < transform.childCount; i++)
			{
				platform = transform.GetChild(i);
				platform.Translate(-platformSpeed, 0, 0);
				if(platform.position.x < -20f)
					Destroy(platform.gameObject);
			}
		}

		if(activeSpawn){
			float dist = spawnLocation.transform.position.x - recentPlatform.transform.position.x;
			if(dist > 1.5f && activeSpawn)
			{
				spawnPlatform();
			}
		}

		if(platformSpeed != maxPlatformSpeed)
			maxXDistance = ((1/Time.deltaTime) * platformSpeed) - 2f;

		updatePlatformSpeed();

	}

	void spawnPlatform()
	{		
		//create next platform off the last one
		Transform newPlat = Instantiate(platPrefab, recentPlatform.transform.position, platPrefab.transform.rotation) as Transform;

		//RNG scale x
		int rngScale = Mathf.RoundToInt(Random.value * 4) + 4;
		Vector3 tempScale = newPlat.localScale;
		tempScale.x = rngScale;
		newPlat.localScale = tempScale;

		//TODO RNG up/down + distance from previous
		float rngY = Random.value * (maxYDistance - minYDistance) + minYDistance;
		float rngX = Random.value * (maxXDistance - minXDistance) + minXDistance;

		float recentPlatSize = recentPlatform.transform.position.x - recentPlatform.transform.FindChild("xRef").transform.position.x;
		float platSize = newPlat.position.x - newPlat.FindChild("xRef").transform.position.x;
		Vector3 trans = new Vector3(recentPlatSize + platSize + rngX, rngY, 0);
		newPlat.Translate(trans);

		//TODO clamp top(max) bottom(min)
		Vector3 clamped = newPlat.position;
		clamped.y = Mathf.Clamp(clamped.y, minBottom + 2f, maxTop - 2f);
		newPlat.position = clamped;
		
		//set new platform as recent and set terrain as parent
		recentPlatform = newPlat.gameObject;
		newPlat.parent = this.transform;
		newPlat.name = "platform" + platformID++;


	}

	void updatePlatformSpeed()
	{
		float update = (maxPlatformSpeed - 0.04f) / ((1/Time.deltaTime) * timeToMax);
		platformSpeed += update;
		platformSpeed = Mathf.Clamp(platformSpeed, 0.04f, maxPlatformSpeed);
	}

}
