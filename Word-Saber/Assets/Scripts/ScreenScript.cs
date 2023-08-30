using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenScript : MonoBehaviour
{
    //Game Controller script
    [SerializeField] TextMeshPro TimeBox;
    [SerializeField] TextMeshPro TargetWordTitle;
    [SerializeField] TextMeshPro TimerTitle;
    [SerializeField] GameObject Spawner;


    public float GameTime = 600f;
    private bool IsPlaying = false;
    private float CurrentTime;
    public float BonusTime = 200f;
    public float NegativeTime = 5f;






    // Start is called before the first frame update
    void Start()
    {
        IsPlaying = true;
        CurrentTime = GameTime;


    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {
            CurrentTime -= Time.deltaTime;

            if (CurrentTime > 0)
            {
                TimeBox.text = CurrentTime.ToString("F2");
            }

            else if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                TimeBox.text = "Game Over";
                IsPlaying = false;
                Destroy(Spawner);
            }
        }
    }

    public void ScoreBonus()
    {
        CurrentTime += BonusTime;
    }

    public void ScorePenalty()
    {
        CurrentTime -= NegativeTime;
    }

    public void GameSuccess()

    {
        IsPlaying = false;
        Destroy(Spawner);
        Destroy(TargetWordTitle);
        Destroy(TimerTitle);
        TimeBox.text = "You got it right!";
    
    }


}
