using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetsVaisseau : MonoBehaviour
{

    [SerializeField] float amplitudePitchVariation = 0.2f;
    [SerializeField] AudioSource audi;
    [SerializeField] float distanceMinEffet = 1f;
    [SerializeField] float distanceMaxeffet = 10f;
    [SerializeField] float distortionMax = 3f;
    [SerializeField] GameObject distortionMaterial;
    [SerializeField] SolDistance sol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audi.pitch = 1 + (GetComponent<Rigidbody>().velocity.magnitude)/100f * amplitudePitchVariation;
        //distortionMaterial.SetFloat(0,Mathf.Lerp(0f,distortionMax,  (distanceMaxeffet - sol.distance)/(distanceMaxeffet-distanceMinEffet)  ));
        Material mat = distortionMaterial.GetComponent<MeshRenderer>().material;
        mat.SetFloat("DistortionFactor",0f);
    }
}
