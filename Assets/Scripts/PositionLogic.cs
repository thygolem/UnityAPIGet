using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionLogic : MonoBehaviour
{

    public Text positionText;
    public Text countdownText;

    private string userPosition;
    // Declare and initialize
    private int randomX, randomY, randomZ;

    float currentTime = 0f;
    float startingTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        positionText.text = "B/F/Z";
        currentTime = startingTime;

    }

    void Update()
    {
        // STOP TIMER: https://answers.unity.com/questions/1177899/how-can-i-stop-timer.html
        // https://www.youtube.com/watch?v=ihTRHr6EvFw
        randomX = GetRandomPosition(-10, 10);
        randomY = GetRandomPosition(-10, 10);
        randomZ = GetRandomPosition(-10, 10);
        float stopTheTime;
        stopTheTime = Time.deltaTime;
        currentTime -= 1 * stopTheTime;
        countdownText.text = currentTime.ToString("0");
        if (currentTime <=0 )
        {
            countdownText.text = "Device was in ";
            stopTheTime = 0;
        }
        Debug.Log(currentTime);
    }

    public void OnButtonClick()
    {

        currentTime = 10f;
        print(currentTime);


        if(randomX > 0 & randomY > 0 & randomZ > 0)
        {
            positionText.text = "ZONE 1";
        }
        else if(randomX < 0 & randomY > 0 & randomZ > 0)
        {
            positionText.text = "ZONE 2";
        }
        else if(randomX < 0 & randomY < 0 & randomZ > 0)
        {
            positionText.text = "ZONE 3";
        }
        else if(randomX > 0 & randomY < 0 & randomZ > 0)
        {
            positionText.text = "ZONE 4";
        }
        else if(randomX > 0 & randomY > 0 & randomZ < 0)
        {
            positionText.text = "ZONE 5";
        }
        else if(randomX < 0 & randomY > 0 & randomZ < 0)
        {
            positionText.text = "ZONE 6";
        }
        else if(randomX < 0 & randomY < 0 & randomZ < 0)
        {
            positionText.text = "ZONE 7";
        }
        else if(randomX > 0 & randomY < 0 & randomZ < 0)
        {
            positionText.text = "ZONE 8";
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
            random = random + 1;
            return random;
        }
        else
        {
            return random;
        }
    }
}
