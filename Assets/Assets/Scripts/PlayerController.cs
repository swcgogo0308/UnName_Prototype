using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public VirtualJoystick joystick;
    public float moveSpeed;
    public float drag = 1.0f;
    private float moveSpeedX;
    private float moveSpeedY;

    private Vector2 _moveVector;

    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start ()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.drag = drag; //브레이크
        _moveVector = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void FixedUpdate() //Update대신 쓰는 함수
    {
        HandleInput();
        Move();
    }

    public void HandleInput()
    {
        _moveVector = PoolInput(); //_moveVector에 값을 받아옴
    }

    public Vector2 PoolInput()
    {
        float h = joystick.GetHorizontalValue(); //조이스틱에서 X값을 받아옴
        float v = joystick.GetVerticalValue(); //조이스틱에서 Y값을 받아옴
        moveSpeedX = h * moveSpeed; //조이스틱을 얼마나 당겼는지에 따라 X속도 조절
        moveSpeedY = v * moveSpeed; //조이스틱을 얼마나 당겼는지에 따라 Y속도 조절
        if (moveSpeedX < 0)
            moveSpeedX = -moveSpeedX; //속도가 음수가 되면 안되니 양수로 바꿔줌
        if (moveSpeedY < 0)
            moveSpeedY = -moveSpeedY; //속도가 음수가 되면 안되니 양수로 바꿔줌
        Vector2 moveDir = new Vector2(h, v).normalized; //노멀라이즈

        return moveDir;
    }

    public void Move()
    {
        _moveVector.x *= moveSpeedX;
        _moveVector.y *= moveSpeedY;
        rb2D.AddForce(_moveVector);
    }
}
