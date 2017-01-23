using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public float wait = 5f;

	void Start () {
		Invoke ("Remove", wait);
	}

	void Remove () {
		Pooler.instance.ReturnToPool (this.gameObject);
	}
}
