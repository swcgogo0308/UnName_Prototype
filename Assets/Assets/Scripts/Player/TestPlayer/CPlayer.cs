﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

    public int health;

	public void moveEvent(Vector3 movePositionValue)
    {
        transform.position += movePositionValue;
    }

    
}
