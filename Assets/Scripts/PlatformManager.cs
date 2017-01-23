using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public Transform platformParent;
	public Transform platformSpawnLocation;
	public float leftEdge;
	public float rightEdge;
	public bool initialRun = true;

	public AnimationCurve spaceBetweenPlatforms;
	private Vector3 lastSpawnPosition;
	private Vector3 nextSpawnPosition;

	private float zPos = 0;
	private float yPos;
	private float xPos;

	private GameObject platform;

	private int platformSize;

	void Start () {
		GameManager.instance.platformManager = this;
	}

	void Update () {
		StartCoroutine (SpawnPlatform ());
	}
		
	IEnumerator SpawnPlatform () 
	{
		yield return new WaitForSeconds (GameManager.instance.gameStartWaitTime);

		zPos = 0;

		while (!GameManager.instance.isGameOver) {
			yield return new WaitForSeconds (1f);
			xPos = Random.Range (leftEdge, rightEdge);
			if (initialRun) {
				yPos = platformSpawnLocation.position.y;
				initialRun = false;
			} else {
				yPos = lastSpawnPosition.y + Random.Range (spaceBetweenPlatforms.keys [0].value, spaceBetweenPlatforms.keys [1].value);
			}

			nextSpawnPosition = new Vector3 (xPos, yPos, zPos);

			platformSize = Random.Range (1, 3);
			platform = Pooler.instance.RequestFromPool (platformSize);
			if (platform != null) {
				platform.transform.position = nextSpawnPosition;
				platform.SetActive (true);
				lastSpawnPosition = platform.transform.position;
			}

		}
	}
}
