using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Video;
using LitJson;
using System;

public class AnminatorRecording : MonoBehaviour
{
    public GameObject[] Bone;
    private int frames;
    private string path = "/Data/data.json";
    private JsonData jsondata;
    private JsonData key;
    float PosX;
    float PosY;
    float PosZ;
    float RorX;
    float RorY;
    float RorZ;

    private void Start()
    {
        string json = File.ReadAllText(Application.dataPath + path);
        jsondata = JsonMapper.ToObject(json);
        for (int i = 0; i < jsondata.Count; i++)
        {
             key = jsondata[i];
        }
    }

    //数据还原
    private void Update()
    {
        
        DataIntoBone(frames);
        frames = frames + 1;
    }
    private void DataIntoBone(int frame)
    {
        key = jsondata[frame];
        Debug.Log(frame);
        for (int i = 0; i < key.Count; i++)
        {
            Debug.Log(key[i]["Info"]["Jointname"]);            
            PosX = Convert.ToSingle(key[i]["Info"]["transformX"].ToString());
            PosY = Convert.ToSingle(key[i]["Info"]["transformY"].ToString());
            PosZ = Convert.ToSingle(key[i]["Info"]["transformZ"].ToString());
            RorX = Convert.ToSingle(key[i]["Info"]["rotationX"].ToString());
            RorY = Convert.ToSingle(key[i]["Info"]["rotationY"].ToString());
            RorZ = Convert.ToSingle(key[i]["Info"]["rotationZ"].ToString());
            Bone[i].transform.position = new Vector3(PosX, PosY, PosZ);
            Bone[i].transform.rotation = new Quaternion(RorX, RorY, RorZ, 0);
        }
    }
}
