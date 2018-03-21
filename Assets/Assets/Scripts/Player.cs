using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public GameObject shootPrefab; //발사할 레이저를 저장합니다.
	public bool canShoot = true; //레이저를 쏠 수 있는 상태인지 검사합니다.
	const float shootDelay = 0.5f; //레이저를 쏘는 주기를 정해줍니다.
	float shootTimer = 0; //시간을 잴 타이머를 만들어줍니다.

	void ShootControl() // 발사를 관리하는 함수 입니다.
	{
		if (canShoot) // 쏠 수 있는 상태인지 검사합니다.
		{
			if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) //쿨타임이 지났는지와, 공격키인 스페이스가 눌려있는지 검사합니다.
			{
				Instantiate(shootPrefab, transform.position, Quaternion.identity); //레이저를 생성해줍니다.
				shootTimer = 0; //쿨타임을 다시 카운트 합니다.
			}
			shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ShootControl ();
	}
}
