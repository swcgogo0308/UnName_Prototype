using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapManager : MonoBehaviour {

	public GameObject map;

	public GameObject[] miniMaptypes;

	private GameObject currentMapType;

	private int maxMapCount;

	// Use this for initialization
	void Start () {
		GameObject miniMapPanel = GameObject.FindGameObjectWithTag ("MiniMap");

		maxMapCount = miniMaptypes.Length;

		int randomMapType = Random.Range (0, maxMapCount);

		currentMapType = Instantiate (miniMaptypes [randomMapType]);

		currentMapType.transform.SetParent(miniMapPanel.transform);

		currentMapType.transform.position = miniMapPanel.transform.position;

		//Debug.Log (currentMapType.transform.Find ("Image (3)").transform.localPosition);
		for (int i = 0, max = maxMapCount; i < max; i++) {
			Vector3 a = currentMapType.transform.Find ("Image (" + i + ")").transform.localPosition;

			GameObject mapObj = Instantiate (map);
			mapObj.transform.position = new Vector3 (a.x , a.y, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
