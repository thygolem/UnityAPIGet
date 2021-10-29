using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.UI;



public class ReadPosition : MonoBehaviour
{
    private string jsonString;
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
        currentTime = startingTime;

        // Devices path
        var url = "http://127.0.0.1:8000/devices/615b1711945a9d861ca922d2";
        using var www = UnityWebRequest.Get(url);
        Device ESP = JsonUtility.FromJson<Device>(jsonString);

    }

    // Update is called once per frame
    void Update()
    {   

        // Ejecutar el void TestGet() cada segundo par
        currentTime += 1 * Time.deltaTime;
        //Debug.Log((int)currentTime);
        if ((int)currentTime%2==0)
        {
         TestGet();
        }


    }

    

    // Crear un botón de acceso directo 
    [ContextMenu("Test Get")] 
    public async void TestGet()
    {   
        var url = "http://127.0.0.1:8000/devices/617927f7f88c028aa7e6bc5c";
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
        
        // 
        Device ESP = JsonUtility.FromJson<Device>(jsonString);

        showEspNear.text = ESP.near_mac; // UI
        showTime.text = ESP.espTime; // UI
        showRssi.text = ESP.currentRssi.ToString(""); // UI

        if (ESP.esp_mac == "4c:11:ae:8b:4c:94")
        {
            BLE.position = ZoneA.position;
            //BLE.transform.Translate(x: xPosition, y: yPosition, z: zPosition);
        }
        else if(ESP.esp_mac == "94:b9:7e:fb:21:b8")
        {
            BLE.position = ZoneH.position;
        }
        //showPosition.text = ESP.xPosition + ESP.yPosition + ESP.zPosition;
        
    }
}
