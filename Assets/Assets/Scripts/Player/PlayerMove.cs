using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D rigid;
    Vector3 movement;

    public float moveSpeed = 5.0f;
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Moving();
	}

    private void Moving()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        movement = new Vector3(hor, ver, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}