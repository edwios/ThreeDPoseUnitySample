using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;


public class SaveFiles : MonoBehaviour
{
    private int frames;
    private string path = "/Data/data.json";    
    List<InfoItem> infoitems;
    string messsageInfo;
    Vector3 postion;
    Quaternion roration;
    ThreeDPoseScript poseScriptJoint;
    Dictionary<string, List<InfoItem>> directory = new Dictionary<string, List<InfoItem>>();

    // Start is called before the first frame update
    void Start()
    {        
        infoitems = new List<InfoItem>();
        poseScriptJoint = GetComponent<ThreeDPoseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        frames = frames + 1;
        for (int i = 0; i < poseScriptJoint.jointPoints.Length; i++)
        {
            if (i!=11||i!=13)
            {
                Debug.Log("eye null");
            }
            else
            {
                InfoItem infoitem = new InfoItem();
                infoitem.Info.transformX = poseScriptJoint.jointPoints[i].Transform.position.x.ToString();
                infoitem.Info.transformY = poseScriptJoint.jointPoints[i].Transform.position.x.ToString();
                infoitem.Info.transformZ = poseScriptJoint.jointPoints[i].Transform.position.x.ToString();
                infoitem.Info.rotationX = poseScriptJoint.jointPoints[i].Transform.rotation.x.ToString();
                infoitem.Info.rotationY = poseScriptJoint.jointPoints[i].Transform.rotation.x.ToString();
                infoitem.Info.rotationZ = poseScriptJoint.jointPoints[i].Transform.rotation.x.ToString();
                infoitem.Info.Jointname = poseScriptJoint.jointPoints[i].Transform.name;
                infoitems.Add(infoitem);
            }
            
        }
        directory.Add(frames.ToString(), infoitems);
        OnClickSave();
        infoitems.Clear();
    }

   
   void OnClickSave()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            StreamWriter sw = new StreamWriter(Application.dataPath + path);
            messsageInfo = JsonMapper.ToJson(directory);
            sw.Write(messsageInfo);
            sw.Close();
        }
    }
}




[Serializable]
public class Info
{
    public string Jointname;

    public string transformX;
    public string transformY;
    public string transformZ;

    public string rotationX;
    public string rotationY;
    public string rotationZ;
}
[Serializable]
public class InfoItem
{
    public Info Info=new Info();
}