using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolDistance : MonoBehaviour
{
    public float distance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position,-transform.up);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo,20f)){
            distance = hitInfo.distance;
            //Debug.DrawLine(transform.position,transform.position - transform.up*hitInfo.distance,Color.blue);
        }else{
            distance = 10000f;
        }
    

    }
}
