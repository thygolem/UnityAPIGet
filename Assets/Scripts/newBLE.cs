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
    public GameObject BLEPrefab;
    // Update is called once per frame
    
    string jsonStringUnity;

    //public Text UNITYiD;



    float currentTime = 0f;
    float startingTime = 0f;

    //int prefabCount;

    public List<GameObject> prefabList = new List<GameObject>();

      
    void Start()
    {   
        currentTime = startingTime;
        // Devices path
        var bleurl = "http://127.0.0.1:8000/unity/617bbebf6f481d596789c1da";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonStringUnity);   /**/

        InvokeRepeating("ShowDevices", 1, 1);
            // Qué void usaremos, cuándo empieza y cada cuánto se repite
        Invoke("CancelInvoke", 50);
            // Encontrar la forma de eliminar el parámetro de tiempo de parar 
            //invocación o buscarle una finalidad

    }

    void Update()
    {    
        currentTime += 1 * Time.deltaTime;
        if ((int)currentTime%2==0)
        {
         GetUnityData();
        }

    }   

    void ShowDevices()
    {   
        UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonStringUnity);
        if ( prefabList.Count < UnityData.bledata_count )
        {
            prefabList.Add(Instantiate(BLEPrefab, Vector3.zero, transform.rotation));
            //transform.position = Vector3.Lerp(BLEPrefab.transform.position, ZoneH.position, 0.5f);
        }
        else
        {
            CancelInvoke("ShowDevices");
            Debug.Log("se cancela el invoke");
        }
        
    }

    [ContextMenu("Get Unity Data")] 
    async void GetUnityData()
    {   
        var bleurl = "http://127.0.0.1:8000/unity/617bbebf6f481d596789c1da";
        using var wwwUnity = UnityWebRequest.Get(bleurl);
        wwwUnity.SetRequestHeader("Content-Type", "application/json");
        var operation = wwwUnity.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();
        jsonStringUnity = wwwUnity.downloadHandler.text;
        UnityDevices UnityData = JsonUtility.FromJson<UnityDevices>(jsonStringUnity);
        
        }
    }