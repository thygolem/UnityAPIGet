


/*

ESTE SCRIPT CONTIENE LA DECLARACIÓN DE LAS VARIABLES QUE VAN A USAR OTROS SCRIPTS:

 - ReadPosition.cs => para recoger datos de un dispositivo concreto
        (apunte, UNITYDATA.MONGODB debería recoger el id de cada dispositivo para derivar ese dato
        a BLEDATA.MONGODB)

 - newBLE.cs => nos va a servir para instanciar la cantidad de prefabs que necesitemos.
        Tantos prefabs como "public string bledata_count;" tenga

*/


// tutorial de Using JSONUtility in Unity 5.3 - Working with JSON in Unity: 
// https://www.youtube.com/watch?v=6yDRbnXve_0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class User : MonoBehaviour
{
    
    string path;
    string jsonString;

    void Start()
    {
        //path = Application.streamingAssetsPath + "/Devices.json";
        path = "/home/ubuntu/Escritorio/Simó/INDOOR/Devices.json";
        //path = "/home/ubuntu/Escritorio/Simó/INDOOR/example.json";
        jsonString = File.ReadAllText(path);
        Device ESP = JsonUtility.FromJson<Device>(jsonString);
        //UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonString);   /**/

        //Debug.Log(ESP.id);
        //ESP.currentRssi = -25;
        //string newESP = JsonUtility.ToJson(ESP);
        //Debug.Log(newESP.id);
    }    
}
    
[System.Serializable]
public class Device
{
    public string id;
    public string iss;
    public string esp_mac;
    public string near_mac;
    public int currentRssi;
    public int[] lastRssiS;
    public string espTime;
    public string building ;
    public string floor;
    public string zone;
    public string xPosition;
    public string yPosition;
    public string zPosition;
    public float lat;
    public float lng;
    public bool task;
}
    

//public class UnityDevices
//{
//    public string id;
//    public bool sistema_iniciado;
//    public int bledata_count;
//    public string[] dispositivos;
//    public string near_mac;
//    public string esp_mac;
//    public string status;
//}