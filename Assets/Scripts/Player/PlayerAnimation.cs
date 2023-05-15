using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour{
	public Animator animator;

    public void setMovementAnimation(Vector2 direction){
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetBool("Movement", direction.x != 0 || direction.y != 0);
    }

    public event Action OnChoppingEnd;

    //--- Left Chops ---
    public void chopLeft(int chopsAmount){
        animator.SetInteger("leftChops", chopsAmount);
    }

    //Fires at the end of single chop left animation
    public void decreaseLeftChops(){
        int currentChops = animator.GetInteger("leftChops");
        animator.SetInteger("leftChops", currentChops - 1);

        //Chopping sequence ended
        if(currentChops - 1 == 0) OnChoppingEnd?.Invoke();
    }
    // ------

    //--- Right Chops ---
    public void chopRight(int chopsAmount){
        animator.SetInteger("rightChops", chopsAmount);
    }

    //Fires at the end of single chop right animation
    public void decreaseRightChops(){
        int currentChops = animator.GetInteger("rightChops");
        animator.SetInteger("rightChops", currentChops - 1);

        //Chopping sequence ended
        if(currentChops - 1 == 0) OnChoppingEnd?.Invoke();

    }
    // ------
}
