using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private PlayerController player;

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate() {
        //if (target)
            //transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
        if (player.mCenter) {
            Vector3 destination = new Vector3(transform.position.x, transform.position.y, player.mCenter.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
