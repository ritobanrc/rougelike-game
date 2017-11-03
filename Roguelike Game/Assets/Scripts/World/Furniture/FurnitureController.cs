using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    public string FurniturePrototypesFileName = "Data/FurniturePrototypes.xml";

    private void Awake()
    {
        ReadFurniturePrototypes();
    }

    private void ReadFurniturePrototypes()
    {
        Debug.Log("Reading Furniture Prototypes from " + FurniturePrototypesFileName);
        XmlDocument xmlDoc = new XmlDocument();
        string filePath = Path.Combine(Application.streamingAssetsPath, FurniturePrototypesFileName);
        if (filePath.Contains("://"))
            throw new XmlException("How the actual f*ck did you manage to run this on Web/Mobile/Not Standalone?");
        xmlDoc.Load(filePath);
        foreach(XmlNode xmlNode in xmlDoc.DocumentElement)
        {
            // For each furniture listed

        }
    }
}
