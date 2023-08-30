using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saber : MonoBehaviour
{

    [SerializeField] TargetWordInstantiate TargetWordCreator;// Getting reference to our TargetWordInstantiate Script for the saber to pass the collided letter tag into the letter checker method
                                                             // on the target word instantiator script
   
    

    void Start()
    {
       
    }
    
    void Update()
    {
        

        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit, 2))
        {
            Collider Collider = hit.collider;
            TargetWordCreator.LetterChecker(Collider.tag);
            Destroy(Collider.gameObject);

        }
       


    }
    
}
