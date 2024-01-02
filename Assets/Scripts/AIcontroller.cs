using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AIcontroller : MonoBehaviour
{
    public GameObject Destination,Destination2;
  
    public UnityEvent trigger1;
    public NavMeshAgent otherAgent;
    public Animator myAnimator,myAnimator2;
    public bool AgentStop=true;
    // private Animation myAnimator2;
    // public GameObject bubblechat;
    public float destinationReachedThreshold = 5f, destination2ReachedThreshold = 0.1f;
    private bool enter=false,secondenter=false;
    public float AnimationOFF = 5f;
    public Collider Mycollider;
    // Start is called before the first frame update
    void Start()
    { 
        GameObject otherGameObject = GameObject.FindWithTag("Player");
        // myAnimator2 = otherGameObject2.GetComponent<Animation>();
        // bubblechat.SetActive(false);
        // if (otherGameObject != null)
        // {
        //     otherAgent = otherGameObject.GetComponent<NavMeshAgent>();
        // }
        // Destination = GameObject.FindGameObjectWithTag("Player");
        // agent.SetDestination(Destination.transform.position);
        
    }
     void Update()
    {
        // Check if the NavMeshAgent has reached the destination
         if(enter)
            {
        if (otherAgent.remainingDistance <= destinationReachedThreshold && !otherAgent.pathPending)
        {
             
           
            // Trigger your event or call a method when the destination is reached
            
            Debug.Log(destinationReachedThreshold);
            Debug.Log(otherAgent.pathPending);
            otherAgent.isStopped = AgentStop; 

            // otherAgent.SetDestination(Destination.transform.position);
            
            DestinationReachedEvent();

        }
            }
        if(secondenter)
            {
         if (otherAgent.remainingDistance <= destination2ReachedThreshold && !otherAgent.pathPending)
        {

        
            myAnimator.SetTrigger("turn2");
            // StartCoroutine(GiveMeSomeotherSeconds());
            // myAnimator.SetTrigger("dance2");
            
            // myAnimator2.SetTrigger("permit");
            otherAgent.isStopped = AgentStop; 
           
secondenter=false;

        }
        }
    }

    void DestinationReachedEvent()
    {
        // Your code to handle the event when the destination is reached
        if (otherAgent.remainingDistance <= destinationReachedThreshold && !otherAgent.pathPending)
        {
        Debug.Log("Destination reached!");
        
        myAnimator.SetTrigger("dance");
        
        myAnimator2.SetTrigger("permit");
        // bubblechat.SetActive(true);
        // myAnimator2.Play("Apearing");
        trigger1.Invoke();
        enter=false;
         StartCoroutine(GiveMeSomeSeconds());

        
        // otherAgent.SetDestination(Destination.transform.position);
           
       
        }
    }

     private IEnumerator GiveMeSomeSeconds()
     {
        yield return new WaitForSeconds(AnimationOFF);
        myAnimator2.SetTrigger("back");
        
    
        
        myAnimator.SetTrigger("turn90");
        yield return new WaitForSeconds(1f);
    
        otherAgent.isStopped = !AgentStop;
        myAnimator.SetTrigger("interact2");
        otherAgent.SetDestination(Destination2.transform.position);
        
        secondenter=true;

     }
    //   private IEnumerator GiveMeSomeotherSeconds()
    //  {
    //     yield return new WaitForSeconds(1f);
       
    //  }



    private void OnTriggerEnter(Collider other)
    {
     if (other.CompareTag("Player") )
     {
        enter=true;
        myAnimator.SetTrigger("turn");
        otherAgent.SetDestination(Destination.transform.position);
        myAnimator.SetTrigger("interact");
        
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
