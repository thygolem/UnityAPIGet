using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionLogic : MonoBehaviour
{

    public Text positionText;
    public Text countdownText;
    private int randomX, randomY, randomZ;
    float currentTime = 0f;
    float startingTime = 0f;
    private bool timerIsActive = true;
    void Start()
    {
        positionText.text = "B/F/Z";
        currentTime = startingTime;
    }

    void Update()
    {       
        if(timerIsActive)
        {
            randomX = GetRandomPosition(-100, 100);
            randomY = GetRandomPosition(-100, 100);
            randomZ = GetRandomPosition(-100, 100);
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            if (currentTime <=0 )
            {
                countdownText.text = "Device was in ";
                currentTime = 0f;
                timerIsActive=false;
                positionText.color = Color.grey;
            }
            Debug.Log(currentTime);

        }
    }

    public void OnButtonClick()
    {
        timerIsActive=true;
        currentTime = 10f;
        print(currentTime);
        positionText.color = Color.green;


        if(randomX > 0 & randomY > 0 & randomZ > 0)
        {
            positionText.text = "ZONE A";
        }
        else if(randomX < 0 & randomY > 0 & randomZ > 0)
        {
            positionText.text = "ZONE B";
        }
        else if(randomX < 0 & randomY < 0 & randomZ > 0)
        {
            positionText.text = "ZONE C";
        }
        else if(randomX > 0 & randomY < 0 & randomZ > 0)
        {
            positionText.text = "ZONE D";
        }
        else if(randomX > 0 & randomY > 0 & randomZ < 0)
        {
            positionText.text = "ZONE E";
        }
        else if(randomX < 0 & randomY > 0 & randomZ < 0)
        {
            positionText.text = "ZONE F";
        }
        else if(randomX < 0 & randomY < 0 & randomZ < 0)
        {
            positionText.text = "ZONE G";
        }
        else if(randomX > 0 & randomY < 0 & randomZ < 0)
        {
            positionText.text = "ZONE H";
        }
        else if(randomX == 0 || randomY == 0 || randomZ == 0)
        {
            positionText.text = "EL DISPOSITVO NO ESTÁ";
        }
            
    }

    private int GetRandomPosition(int min, int max)
    {
        int random = Random.Range(min, max);

        if (random == 0)
        {
            random = random * -1;
            return random;
        }
        else
        {
            return random;
        }
    }
}
