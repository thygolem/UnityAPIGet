using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.UI;



//https://www.youtube.com/watch?v=u1dLdXBTBB8
public class newBLE : MonoBehaviour
{
    public ReadPosition ReadPosition;
    public GameObject BLEPrefab;
    // Update is called once per frame
    
    private string jsonString;

    public Text BLEDeviceCount;


    float currentTime = 0f;
    float startingTime = 0f;
    
    void Start()
    {   
        currentTime = startingTime;

        // Devices path
        var bleurl = "http://127.0.0.1:8000/unity/";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        //UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonString);   /**/

    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Instantiate(BLEPrefab);
            //BLEPrefab.position = ReadPosition.BLE.position;
            Debug.Log(ReadPosition.showRssi.text);
            //Debug.Log(UnityData.sistema_iniciado);

        }

                // Ejecutar el void TestGet() cada segundo par
        currentTime += 1 * Time.deltaTime;
        //Debug.Log((int)currentTime);
        if ((int)currentTime%2==0)
        {
         GetUnityData();
        }    
    }



    // Crear un botón de acceso directo 
    [ContextMenu("Get Unity Data")] 
    public async void GetUnityData()
    {   
        var bleurl = "http://127.0.0.1:8000/unity/";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        wwwUnity.SetRequestHeader("Content-Type", "application/json");
        var operation = wwwUnity.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();
        //if (wwwUnity.result == UnityWebRequest.Result.Success)
            //Debug.Log($"Success: {wwwUnity.downloadHandler.text}");
        //else
            //Debug.Log($"Failed: {wwwUnity.error}");
        jsonString = wwwUnity.downloadHandler.text;
        
        // 
        //UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonString); /**/
        //Debug.Log(jsonString);
        //showRssi.text = ESP.currentRssi.ToString("");
        //
        //BLEDeviceCount.text = UnityData.bledata_count.ToString(""); // UI
        //Debug.Log(UnityData.BLEDeviceCount.text);


        //Debug.Log(ReadPosition.showRssi.text);

        
    }
}
