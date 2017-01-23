using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour {

	public bool encryption = true;
	public string password;

	private Rigidbody2D rb2d;
	private string path;
	private string file;
	private string fullpath;

	void Awake ()
	{
		path = Application.persistentDataPath;
		file = "mySaveFile.save";
		fullpath = path + "/" + file;

		if (encryption)
			fullpath = fullpath + "?encrypt=true" + "&password=" + password.ToString ();
		
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		Load ();
	}

	void LateUpdate ()
	{
		Save ();
	}

	void OnApplicationQuit()
	{
		Save ();
	}

	void Save () 
	{
		ES2.Save (rb2d.angularVelocity, fullpath + "&tag=myAngularVelocity");
		ES2.Save (rb2d.velocity, fullpath + "&tag=myVelocity");
		ES2.Save (transform.position, fullpath + "&tag=myPosition");
		ES2.Save (transform.rotation, fullpath + "&tag=myRotation");
		ES2.Save (transform.localScale, fullpath + "&tag=mySize");
	}

	void Load ()
	{
		rb2d.angularVelocity = ES2.Load<float> (fullpath + "&tag=myAngularVelocity");
		rb2d.velocity = ES2.Load<Vector2> (fullpath + "&tag=myVelocity");
		transform.position = ES2.Load<Vector3> (fullpath + "&tag=myPosition");
		transform.rotation = ES2.Load<Quaternion> (fullpath + "&tag=myRotation");
		transform.localScale = ES2.Load<Vector3> (fullpath + "&tag=mySize");
	}


}
