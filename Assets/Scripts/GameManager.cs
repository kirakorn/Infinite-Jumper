using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject player;
	public PlatformManager platformManager;
	public CameraFollow camFollow;

	public bool isGameOver = false;
	public bool characterAlive = true;

	public float gameStartWaitTime = 3f;

	void Awake () 
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void Update () 
	{
		CheckIfPlayerAlive ();
		CheckIfGameOver ();
	}

	void CheckIfPlayerAlive() 
	{
		if (player.gameObject.activeSelf) {
			characterAlive = true;
		} else {
			characterAlive = false;
		}
	}

	void CheckIfGameOver() 
	{
		if (!characterAlive) {
			isGameOver = true;

			platformManager.enabled = false;
			camFollow.enabled = false;
		} else {
			isGameOver = false;
		}
	}
}
