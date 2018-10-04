using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Player") {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            pc.Reset();
        }
    }
}
