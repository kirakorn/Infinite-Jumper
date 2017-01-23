using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

	public static Pooler instance;

	public int intialPoolSize;
	public GameObject platformsPrefabsm;
	public GameObject platformsPrefabmd;
	public GameObject platformsPrefablg;
	public bool willGrow;

	private GameObject platform;
	private List<GameObject> platformssm;
	private List<GameObject> platformsmd;
	private List<GameObject> platformslg;

	void Start () 
	{

		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		platformssm = new List<GameObject> ();
		platformssm.Clear ();
		platformsmd = new List<GameObject> ();
		platformsmd.Clear ();
		platformslg = new List<GameObject> ();
		platformslg.Clear ();

		PopulatePool ();
	}
		
	public GameObject RequestFromPool (int size) 
	{
		switch (size) {
		case 1:
			for (int i = 0; i < platformssm.Count; i++) {
				if (platformssm [i].activeSelf == true)
					continue;

				if (platformssm [i].activeSelf == false) {
					platform = platformssm [i];
					return platform;
				}
			}

			if (willGrow)
				return expandPool (1);
			
			return null;
		case 2:
			for (int i = 0; i < platformsmd.Count; i++) {
				if (platformsmd [i].activeSelf == true)
					continue;

				if (platformsmd [i].activeSelf == false) {
					platform = platformsmd [i];
					return platform;
				}
			}

			if (willGrow)
				return expandPool (2);

			return null;
		case 3:
			for (int i = 0; i < platformslg.Count; i++) {
				if (platformslg [i].activeSelf == true)
					continue;

				if (platformslg [i].activeSelf == false) {
					platform = platformslg [i];
					return platform;
				}
			}

			if (willGrow)
				return expandPool (3);

			return null;
		}

		return null;
	}

	public void ReturnToPool (GameObject obj)
	{
		obj.SetActive (false);
		obj.transform.position = transform.position;
		if (obj.transform.parent != this.transform)
			obj.transform.parent = this.transform;
	}

	public GameObject expandPool (int size)
	{
		GameObject obj;
		switch (size) {
		case 1:
			obj = Instantiate (platformsPrefabsm, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
			return obj;
		case 2:
			obj = Instantiate (platformsPrefabmd, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
			return obj;
		case 3:
			obj = Instantiate (platformsPrefablg, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
			return obj;
		}
		return null;
	}

	void PopulatePool ()
	{
		for (int i = 0; i <= intialPoolSize; i++) {
			GameObject obj = Instantiate (platformsPrefabsm, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
		}
		for (int i = 0; i <= intialPoolSize; i++) {
			GameObject obj = Instantiate (platformsPrefabmd, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
		}
		for (int i = 0; i <= intialPoolSize; i++) {
			GameObject obj = Instantiate (platformsPrefablg, transform.position, Quaternion.identity, transform);
			obj.SetActive (false);
			platformssm.Add (obj);
		}
	}
}
