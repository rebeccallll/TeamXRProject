using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetWordInstantiate : MonoBehaviour
{
    [SerializeField] WordData[] Words; // getting our Words from the scriptable objects
    [SerializeField] Transform TargetWordLocation;// Location of Instantitation on Screen
    [SerializeField] ScreenScript Screen;
    public TMP_Text SpawnedLetter;
    public List<TMP_Text> SpawnedLetterList = new List<TMP_Text>();// List containing our spawned letters
    public int WordScore;




    public void Start()
    { // Selecting a random word and passing on its letter prefabs from the Scriptable object to be instantiated on the screen(transform - Target Word Location)
        WordData ChosenWordData = Words[Random.Range(0, Words.Length)];

        foreach (TMP_Text letter in ChosenWordData.LettersintheWord)
        {
            SpawnedLetter = Instantiate(letter, TargetWordLocation);
            SpawnedLetter.color = Color.white;
            SpawnedLetterList.Add(SpawnedLetter);
        }

    }

    // Method called by Saber script passing the tag of the collided letter
    // Runs a for loop on all the letters of our SpawnedLetterList to compare the tag with the letter.text
    public void LetterChecker(string collidertag)
    {
        for (int x = 0; x < SpawnedLetterList.Count; x++)

        {
            if (SpawnedLetterList[x].text == collidertag)
            {
                SpawnedLetterList[x].color = Color.black;
                WordCompletionChecker();
                Screen.ScoreBonus();
            }

            else
            { Screen.ScorePenalty(); }
        }
    }


    // Method called by LetterChecker  to check if the entire word is completely black, checked after every correctly hit letter
    public void WordCompletionChecker()
    {
        WordScore = 0;

        for (int i = 0; i < SpawnedLetterList.Count; i++)
        {
            if (SpawnedLetterList[i].color == Color.black)
            {
                WordScore++;
            }
        }

        if (WordScore == SpawnedLetterList.Count)
        {
            Screen.GameSuccess();
        }
    }

}
