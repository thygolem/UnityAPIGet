using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.UI;
using System;



//https://www.youtube.com/watch?v=u1dLdXBTBB8
public class newBLE : MonoBehaviour
{
    public ReadPosition ReadPosition;
    public GameObject BLEPrefab;
    // Update is called once per frame
    
    string jsonStringUnity;

    //public Text UNITYiD;

    public Transform ZoneA, ZoneB, ZoneC, ZoneD, ZoneE, ZoneF, ZoneG, ZoneH;
    public Text BLEDeviceCount;

    float currentTime = 0f;
    float startingTime = 0f;
    
    void Start()
    {   
        currentTime = startingTime;

        // Devices path
        var bleurl = "http://127.0.0.1:8000/unity/617bbebf6f481d596789c1da";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonStringUnity);   /**/

    }
    
    void Update()
    {

        /*if ()
        {
            -Hay que hacer una lógica con 'Unity001'
                para recoja el esp_mac de cada near_mac
                y también el status para cambiar color a 
                gris en caso de status==False.

            -Cada near_mac estará asociada a una zona y
                habrá diferentes tipos de zonas

            -Se debería hacer así porque el entorno de Unity
                es el que va a manejar los cambios de asignación
                de zonas a los esp_mac.

            -Conviene crear una variable en el script que vaya
                vinculado a cada prefab de zona.
        }
        */

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject activo = Instantiate(BLEPrefab);
            activo.transform.position = ZoneA.transform.position;
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



    // Crear un botón de acceso directo desde el inspector
    [ContextMenu("Get Unity Data")] 
    public async void GetUnityData()
    {   
        var bleurl = "http://127.0.0.1:8000/unity/617bbebf6f481d596789c1da";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        wwwUnity.SetRequestHeader("Content-Type", "application/json");
        var operation = wwwUnity.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();
        //if (wwwUnity.result == UnityWebRequest.Result.Success)
            //Debug.Log($"Success: {wwwUnity.downloadHandler.text}");
        //else
            //Debug.Log($"Failed: {wwwUnity.error}");
        jsonStringUnity = wwwUnity.downloadHandler.text;
        

        UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonStringUnity);

        try //https://docs.unity3d.com/es/530/Manual/NullReferenceException.html
        {

    //public string id;
    //public string unityId;
    //public bool sistema_iniciado;
    //public int bledata_count;
    //public string[] dispositivos;
    //        
            
            BLEDeviceCount.text = UnityData.bledata_count.ToString(""); // UI
            //Debug.Log(BLEDeviceCount.text);
        }       
        catch (NullReferenceException) 
        {
            Debug.Log("UnityData.bledata_count not set to BLEDEviceCount.text");
        }

        //Debug.Log(ReadPosition.showRssi.text);

        
    }
}
