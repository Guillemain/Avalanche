using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetsVaisseau : MonoBehaviour
{

    [SerializeField] float amplitudePitchVariation = 0.2f;
    [SerializeField] AudioSource audi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audi.pitch = 1 + (GetComponent<Rigidbody>().velocity.magnitude)/100f * amplitudePitchVariation;
    }
}
