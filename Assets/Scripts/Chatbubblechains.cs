using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chatbubblechains : MonoBehaviour
{
    public TextMeshPro[] boards;
    public float delayBetweenBoards = 2.0f;

    private int currentIndex = 0;
    private bool hasCollided = false;
    private bool exited = true;

    private void Start()
    {
        SetAllBoardsActive(false);
    }

    public void textstarted()
    {
        
        
            StartCoroutine(ShowBoardsWithDelay());
            hasCollided = true;
        
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("destination"))
    //     {
            
    //         exited = false;
    //         StopCoroutine(ShowBoardsWithDelay());
    //         SetAllBoardsActive(false);
    //         currentIndex = 0;
    //     }
    // }

    private IEnumerator ShowBoardsWithDelay()
    {
        while (currentIndex < boards.Length)
        {
            if(!exited)
            {
                break;
            }
            SetBoardActive(currentIndex, true);
            yield return new WaitForSeconds(delayBetweenBoards);
            if (currentIndex < boards.Length)
            {
            SetBoardActive(currentIndex, false);
            }
            currentIndex++;
            yield return null;
            
        }
    }

    private void SetAllBoardsActive(bool active)
    {
        foreach (TextMeshPro board in boards)
        {
            board.enabled=!board.enabled;
        }
    }

    private void SetBoardActive(int index, bool active)
    {
        if (index >= 0 && index < boards.Length)
        {
            boards[index].enabled=!boards[index].enabled;
        }
    }
}
