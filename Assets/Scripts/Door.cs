using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;

    public void Open(){
        animator.SetBool("isOpen", true);
    }

    public void Close(){
        animator.SetBool("isOpen", false);
    }

    public void Interact(){
        if(isOpen){
            Close();
            isOpen = false;
        }else if(!isOpen){
            Open();
            isOpen = true;
        }
    }

}
