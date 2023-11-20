using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMoving : MonoBehaviour
{
    [SerializeField] private Animator myBlade = null;
    [SerializeField] private string BladeAni = "BladeStarter";
    private bool BladeOn= false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    public void BladeRunning()
    {
       
       if(BladeOn)
       {
        myBlade.speed = 4.0f;
        myBlade.Play(BladeAni,0,0.0f);
       }
       else
       {
        myBlade.speed = 0.0f;
       }
       BladeOn=!BladeOn;
    }


}
