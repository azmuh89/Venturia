using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public float ClampLeft;
    public float ClampRight;
    public float ClampDown;
    public float ClampUp;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -ClampLeft, ClampRight),
            Mathf.Clamp(player.position.y, -ClampDown, ClampUp),
            transform.position.z);
    }
}
