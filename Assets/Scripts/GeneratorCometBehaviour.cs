using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCometBehaviour : MonoBehaviour {
    public float minTime, maxTime;
    public float minVelocity, maxVelocity;
    public float minTam, maxTam, delay;
    public int minComets, maxComets, maxTimeComet;
    public Vector3 direction;
    public GameObject cometModel;
    
    private float timeGen;
    private float actualyTime;
	// Use this for initialization
	void Start () {		        
	}
	
	// Update is called once per frame
	void Update () {
        actualyTime += Time.deltaTime;
        if(actualyTime >= timeGen)
        {
            StartCoroutine(ThrowComet(Random.Range(minComets, maxComets), direction));
            actualyTime = 0;
            timeGen = Random.Range(minTime, maxTime);
        }
	}

    public IEnumerator ThrowComet(int qtd, Vector3 direction){
        for (int i = 0; i < qtd; i++) {
            GameObject clone = Instantiate(cometModel, transform.position, transform.localRotation) as GameObject;
            float tamComet = Random.Range(minTam, maxTam);
            clone.transform.localScale = Vector3.one * tamComet;

            clone.name = "Comet";

            CometBehaviour comet = clone.GetComponent<CometBehaviour>();
            //Randomize velocity
            comet.maxTimeActive = maxTimeComet;
            //Randomize velocity
            comet.velocity = Random.Range(minVelocity, maxVelocity);
            //seting direction
            comet.direction = direction;
            //wait for throw new comet
            yield return new WaitForSecondsRealtime(delay);
        }
    }
}
