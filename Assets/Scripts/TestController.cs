using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using SimpleJSON;

public class TestController : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        //var url = "http://127.0.0.1:8000/devices/";
        var url = "http://127.0.0.1:8000/devices/61669d21be54d7e531d45c5e";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while(!operation.isDone)
            await Task.Yield();

        if (www.result == UnityWebRequest.Result.Success)
            Debug.Log($"Success: {www.downloadHandler.text}");
        else
            Debug.Log($"Failed: {www.error}");
    }
}