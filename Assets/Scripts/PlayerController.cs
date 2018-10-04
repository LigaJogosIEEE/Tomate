using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform mCenter;
    [SerializeField]
    private float mBaseSpeed;

    private Vector3 startPos;

    public Transform[] development;
    public int index;
    private bool clockwise;

    private void Awake() {
        startPos = transform.position;
    }

    void Start () {
        index = -1;
        clockwise = true;
	}
	
	void Update () {
        Controls();
        Gravitate();
	}

    public void Reset() {
        transform.position = startPos;
        index = 0;
        clockwise = false;
        mCenter = development[0];
    }

    private void Controls() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            MoveToNearbyPlanet();
        }
    }

    private void MoveToNearbyPlanet() {
        if ((index + 1) < development.Length) {
            mCenter = development[++index];
            clockwise = !clockwise;
        }
    }

    private void Gravitate() {
        if (mCenter) {
            transform.RotateAround(mCenter.position, Vector3.up, (clockwise ? mBaseSpeed : -mBaseSpeed) * Time.deltaTime);
        }
    }
}
