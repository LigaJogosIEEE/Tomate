using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetColloring : MonoBehaviour {
    public Material planetTypes;    
    public bool gerarCores;    
    public Color colorEffect;

    private MeshRenderer[] materials;

    // Use this for initialization
    void Start () {
        if (gerarCores) {
            colorEffect = GerarCores(colorEffect, 0);
        }

        materials = GetComponentsInChildren<MeshRenderer>();

        Color colorAnterior = colorEffect;
        foreach (MeshRenderer m in materials) {
            colorAnterior = GerarCores(colorAnterior, 0.3f);
            m.materials[0].color = colorAnterior;
        }
    }

    public Color GerarCores(Color color, float difCores) {
        //se diferente de 0, quer cores proximas
        int paint = difCores != 0 ? 1 : 0;
        
        color.r = (paint * color.r) + Random.Range(-difCores, difCores);
        color.g = (paint * color.g) + Random.Range(-difCores, difCores);
        color.b = (paint * color.b) + Random.Range(-difCores, difCores);    
        color.a = Random.Range(0.5f, 1f);

        return color;
    }

    // Update is called once per frame
    void Update () {

	}
}
