using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody2D rb2d;

	void Start ()
	{
		print ("started");
		rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine(RandomMover());
	}

	IEnumerator RandomMover ()
	{
		float number = 0f;
		float moveForce = 0f;
		int counter = 0;
		Vector2 direction = Vector2.zero;
		yield return new WaitForSeconds (3f);
		print ("wait 3 seconds over");
		while (true) {
			counter++;
			number = Random.value * 10f;
			moveForce = Random.value * 100f;
			switch ((int)number) {
			case 1:
			case 2:
				direction = Vector2.up;
				print ("1-2");
				break;
			case 3:
			case 4:
				direction = Vector2.down;
				print ("3-4");
				break;
			case 5:
			case 6:
				direction = Vector2.left;
				print ("5-6");
				break;
			case 7:
			case 8:
				direction = Vector2.right;
				print ("7-8");
				break;
			case 9:
				rb2d.angularVelocity = Random.value * 300f;
				print ("9");
				break;
			case 10:
				transform.localScale = new Vector3 (transform.localScale.x + 3f, transform.localScale.y + 3f, transform.localScale.z);
				print ("10");
				break;
			case 0:
				print("0");
				transform.localScale = new Vector3 (1, 1, transform.localScale.z);
				break;
			default:
				break;
			}
			rb2d.AddForce (direction * moveForce);
			transform.localScale = new Vector3 (transform.localScale.x - 0.25f, transform.localScale.y - 0.25f, transform.localScale.z);
			yield return new WaitForSeconds (1f);
		}
	}
}
