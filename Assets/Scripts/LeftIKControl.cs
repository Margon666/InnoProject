using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class IKControlLeft : MonoBehaviour {

    protected Animator animator;

    public bool ikActive = false;
    public Transform leftHandObj = null;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if(animator) {
       
            //if the IK is active, set the position and rotation directly to the goal.
            if(ikActive) {

                // Set the look target position, if one has been assigned
                // Set the left hand target position and rotation, if one has been assigned
                if(leftHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
                    animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
                }
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {          
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0);
                animator.SetLookAtWeight(0);
            }
        }
    }
}