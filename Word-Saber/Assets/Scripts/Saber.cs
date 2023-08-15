using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saber : MonoBehaviour
{
    
    [SerializeField] TMP_Text [] TargetLetters;
    [SerializeField] ScreenScript Scriptholder;
    private int WordScore;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        

        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit, 2))
        {
            Collider Collider = hit.collider;
            
            foreach (TMP_Text letterbox in TargetLetters)
            {
                if (Collider.tag == letterbox.text)
                {
                    letterbox.color = Color.black;
                    Scriptholder.Scorer();
                    WordCompletionChecker();

                }

                else
                {
                    Scriptholder.ScorePenalty();
                }
            }

            Destroy(Collider.gameObject);

        }

        
    }
    // if (all letterboxes are of color.black then end game)
    
    public void WordCompletionChecker()
    {
        WordScore = 0; 

        foreach (TMP_Text letterbox in TargetLetters)
        {
            if (letterbox.color == Color.black)
            {
                WordScore += 1;
            }
        }

        if (WordScore == TargetLetters.Length) // Check maybe .Length + 1 works

        {
            Scriptholder.GameSuccess();
        }
    }
}
