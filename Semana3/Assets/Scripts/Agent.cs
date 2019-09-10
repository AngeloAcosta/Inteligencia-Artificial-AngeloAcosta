using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Agent : MonoBehaviour{
    
    Vector3 desired, steer, velocity = Vector3.zero;
    [SerializeField]private float maxSpeed = 1;
    [SerializeField]private float maxSteer = 1;

    Transform target;

    public Text mText;

    private bool hasWin = false;

    void Start(){
        target = GameObject.Find("Target").transform;
    }

    void Update(){
        desired = -(target.position - transform.position).normalized * maxSpeed;
        steer = Vector3.ClampMagnitude(desired - velocity, maxSteer);

        velocity += steer * Time.deltaTime;
        transform.position += velocity  * Time.deltaTime;

        if(transform.position.x <= 1 && transform.position.x >= -1 && transform.position.y <= 1 && transform.position.y >= -1){
            hasWin = true;
            mText.text = "YOU WIN!!";
            Destroy(gameObject,0.5f);
        }
    }

    void OnBecameInvisible(){
        if(!hasWin){
            mText.text = "YOU LOSE!!";
            Destroy(gameObject,0.5f);
        }
    }
}