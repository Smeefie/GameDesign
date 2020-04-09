using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float transitionSpeed = 1f;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        Vector3 CameraPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
        transform.position = CameraPosition;

    }
}
