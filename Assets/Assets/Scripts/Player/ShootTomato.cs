﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {
	private const float _MOVESPEED = 0.45f;
	//총알이 움직일 속도를 상수로 지정해줍시다.
	void Start () {

	}
	void Update () {
		float moveY = _MOVESPEED * Time.deltaTime;
		//이동할 거리를 지정해 줍시다.
		transform.Translate(0, moveY, 0);
		//이동을 반영해줍시다.
	}
}