using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		switch (other.tag) {
		case "Platform":
			print ("Destroying platform");
			Pooler.instance.ReturnToPool (other.gameObject);
			break;
		case "Player":
			print ("Player dead");
			other.gameObject.SetActive (false);
			break;
		default:
			print ("Other thing entered: " + other.gameObject.name);
			break;
		}
	}
}
