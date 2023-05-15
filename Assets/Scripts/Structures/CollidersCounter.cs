using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersCounter : MonoBehaviour{
    private int counter = 0;

    public bool isColliding(){
        return counter > 0;
    }

    void OnTriggerEnter2D(Collider2D collider){
        counter++;
    }

    void OnTriggerExit2D(Collider2D collider){
        counter--;
    }
}
