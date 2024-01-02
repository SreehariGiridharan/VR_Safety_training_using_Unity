using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nextpositionrun : MonoBehaviour
{
    public UnityEvent trigger2;
    public Animator myAnimator,myAnimator2;
    public Collider Mycollider;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
private void OnTriggerEnter(Collider other)
    {
     if (other.CompareTag("Player") )
     {
        
        myAnimator.SetTrigger("dance2");
        myAnimator2.SetTrigger("permit");
        trigger2.Invoke();
     }
    }
      private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the collider exited by a specific object (e.g., tagged as "Player")
        {
            Mycollider.enabled = false; // Disable the collider
        }
    }   

}
