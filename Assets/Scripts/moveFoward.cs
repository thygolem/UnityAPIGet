using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFoward : MonoBehaviour
{
    public Transform ZoneA, ZoneB, ZoneC, ZoneD, ZoneE, ZoneF, ZoneG, ZoneH;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
        //Vector3 a = transform.position;
        //Vector3 b = ZoneH.position;
        //transform.position = Vector3.Lerp(a, b, speed*Time.deltaTime);

        //https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html
    }
}
