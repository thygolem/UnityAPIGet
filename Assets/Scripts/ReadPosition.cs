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
    public Text showPosition;
    // Start is called before the first frame update
    void Start()
    {
        var url = "http://127.0.0.1:8000/devices/615b1711945a9d861ca922d2";
        using var www = UnityWebRequest.Get(url);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        print("HOLA");

    }

    
    [ContextMenu("Test Get")]
    public async void TestGet()
    {   
        var url = "http://127.0.0.1:8000/devices/61669d21be54d7e531d45c5e";

        //var url = "http://127.0.0.1:8000/devices/";
        using var www = UnityWebRequest.Get(url);


        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while(!operation.isDone)
            await Task.Yield();

        if (www.result == UnityWebRequest.Result.Success)
            Debug.Log($"Success: {www.downloadHandler.text}");
        else
            Debug.Log($"Failed: {www.error}");

        jsonString = www.downloadHandler.text;
        Device ESP = JsonUtility.FromJson<Device>(jsonString);
        Debug.Log(ESP.id);
        Debug.Log(ESP.iss);
        Debug.Log(ESP.currentRssi);
        showEspNear.text = ESP.iss;
        showRssi.text = ESP.currentRssi.ToString("");
        showPosition.text = ESP.xPosition + ESP.yPosition + ESP.zPosition;
        
    }
}
