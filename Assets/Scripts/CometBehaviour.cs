using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometBehaviour : MonoBehaviour {
    public float velocity;
    public Vector3 direction;

    public float maxTimeActive;

    private float actualyTime;
	// Use this for initialization
	void Start () {
        if (maxTimeActive == 0)
            maxTimeActive = 10;
	}
	
	// Update is called once per frame
	void Update () {
        actualyTime += Time.deltaTime;
        if(actualyTime >= maxTimeActive)
            Destroy(this.gameObject, 1f);

        transform.Translate(direction * velocity * Time.deltaTime);
    }
}
