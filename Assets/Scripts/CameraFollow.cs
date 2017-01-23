using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	public Transform boundaries;
	public float offset;
	public float scrollSpeed;
	public float waitTime;
	private Vector3 targetPosition;

	void Start ()
	{
		GameManager.instance.camFollow = this;
		targetPosition = new Vector3 (transform.position.x, transform.position.y + Vector2.up.y, transform.position.z);
		StartCoroutine (MoveToPlayer ());
	}

	void Update () 
	{
		if (GameManager.instance.isGameOver) {
			StopCoroutine (MoveToPlayer ());
		} else {
			targetPosition = new Vector3 (transform.position.x, transform.position.y + Vector2.up.y, transform.position.z);
		}
		boundaries.position = transform.position;
	}

	IEnumerator MoveToPlayer()
	{
		yield return new WaitForSeconds (GameManager.instance.gameStartWaitTime);
		while (true) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition , Time.deltaTime * scrollSpeed);
			yield return new WaitForSeconds (waitTime);
		}
	}
}
