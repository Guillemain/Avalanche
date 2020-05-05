using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractionEffet : MonoBehaviour
/// Script de merde de debug
{

    public Material mt;
    // Start is called before the first frame update
    void Start()
    {
        mt = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //print(mt);
    }
}
