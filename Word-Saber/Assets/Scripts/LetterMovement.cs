using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovement : MonoBehaviour
{
    public float SpeedMultiplier = 20f;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward*SpeedMultiplier * Time.deltaTime;
    }
}
