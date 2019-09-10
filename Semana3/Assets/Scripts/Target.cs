using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour{
    
    void Start(){
        
    }

    void Update(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.Scale(new Vector3(1,1,0));    
        transform.position = mousePosition;
    }
}