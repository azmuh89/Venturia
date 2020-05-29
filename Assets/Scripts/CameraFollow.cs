﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float ClampLeft;
    public float ClampRight;
    public float ClampDown;
    public float ClampUp;

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -ClampLeft, ClampRight),
            Mathf.Clamp(player.position.y, -ClampDown, ClampUp),
            transform.position.z);
    }
}
