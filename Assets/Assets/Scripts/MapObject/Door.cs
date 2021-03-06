﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPlayerConflict{
    public Vector2 movePosition;
    CPlayer playerT;

    void Start()
    {
        playerT = FindObjectOfType<CPlayer>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
            PlayerConflict(playerT);
            
    }

    public void PlayerConflict(CPlayer player)
    {
        player.moveEvent(movePosition);
    }


}
