using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDettachment : MonoBehaviour
{
    [SerializeField] private GameObject ThePlayer;
    [SerializeField] private GameObject Thecamera;

    void Awake()
    {
        ThePlayer.SetActive(false);
        Thecamera.SetActive(true);
        StartCoroutine(FinishCUt());
    }

    IEnumerator FinishCUt()
    {
        yield return new WaitForSeconds(5);
        ThePlayer.SetActive(true);
        Thecamera.SetActive(false);
    }



    
}
