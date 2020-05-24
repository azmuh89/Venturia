using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -5f, 5f),
            Mathf.Clamp(player.position.y, -5f, 5f),
            transform.position.z);
    }
}
