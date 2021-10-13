using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.UI;



public class ReadPosition : MonoBehaviour
{
    string jsonString;
    public Text showEspNear;
    public Text showRssi;
    public Text showTime;
    public Transform BLE;

    public Transform ZoneA, ZoneB, ZoneC, ZoneD, ZoneE, ZoneF, ZoneG, ZoneH;

    float currentTime = 0f;
    float startingTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        var url = "http://127.0.0.1:8000/devices/615b1711945a9d861ca922d2";
        using var www = UnityWebRequest.Get(url);
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        Debug.Log((int)currentTime);
        if ((int)currentTime%2==0)
        {
         TestGet();
        }


    }

    
    [ContextMenu("Test Get")]
    public async void TestGet()
    {   
        var url = "http://127.0.0.1:8000/devices/6166c27d8ba41e795554d178";

        //var url = "http://127.0.0.1:8000/devices/";
        using var www = UnityWebRequest.Get(url);


        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while(!operation.isDone)
            await Task.Yield();

        //if (www.result == UnityWebRequest.Result.Success)
            //Debug.Log($"Success: {www.downloadHandler.text}");
        //else
            //Debug.Log($"Failed: {www.error}");

        jsonString = www.downloadHandler.text;
        Device ESP = JsonUtility.FromJson<Device>(jsonString);
        Debug.Log(ESP.esp_mac);
        showEspNear.text = ESP.near_mac;
        showTime.text = ESP.espTime;
        showRssi.text = ESP.currentRssi.ToString("");

        if (ESP.esp_mac == "4c:11:ae:8b:4c:94")
        {
            BLE.position = ZoneA.position;
            //BLE.transform.Translate(x: xPosition, y: yPosition, z: zPosition);
        }
        else if(ESP.esp_mac == "94:b9:7e:fb:27:e4")
        {
            BLE.position = ZoneH.position;
        }
        //showPosition.text = ESP.xPosition + ESP.yPosition + ESP.zPosition;
        
    }
}
