using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBG : MonoBehaviour
{
    public GameObject winBG;
    public GameController winGame;

    private Vector3 startPos;
    private Vector3 endPos;
    private float distance = 25f;
    private float lerpTime = 5;
    private float currentLerpTime = 0;
    private bool keyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = winBG.transform.position;
        endPos = winBG.transform.position + Vector3.back * distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(winGame.score >=100)
        {
            keyHit = true;
        }

        if(keyHit == true)
        {
            currentLerpTime += Time.deltaTime;
            if(currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float Perc = currentLerpTime / lerpTime;
            winBG.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }
}
