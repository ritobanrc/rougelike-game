using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine;
using Utility;

public class FurnitureController : Singleton<FurnitureController>
{
    public string FurniturePrototypesFileName = "Data/FurniturePrototypes.xml";

    public List<FurniturePrototype> FurniturePrototypes { get; private set; }


    private void Awake()
    {
        ReadFurniturePrototypes();
    }

    private void ReadFurniturePrototypes()
    {
        Debug.Log("Reading Furniture Prototypes from " + FurniturePrototypesFileName);
        FurniturePrototypes = new List<FurniturePrototype>();
        XmlDocument xmlDoc = new XmlDocument();
        string filePath = Path.Combine(Application.streamingAssetsPath, FurniturePrototypesFileName);
        if (filePath.Contains("://"))
            throw new XmlException("How the actual f*ck did you manage to run this on Web/Mobile/Not Standalone?");
        xmlDoc.Load(filePath);
        foreach(XmlNode xmlNode in xmlDoc.DocumentElement)
        {   
            /// TODO: This is not scalable! Is there a better way to do this?
            // For each furniture listed, get its information
            string name = xmlNode.Attributes["name"].Value;
            bool hasCol = xmlNode.Attributes["hasCol"].Value == "true";
            bool hasRb = xmlNode.Attributes["hasRb"].Value == "true";
            Color lvlImageColor = Color.black;
            ColorUtility.TryParseHtmlString(xmlNode.SelectSingleNode("LvlImgColor").InnerText, out lvlImageColor);
            Color32 lvlImageColor32 = (Color32)lvlImageColor;
            // Furniture.Graphics.ImagePath - TODO: Handle more complicated graphics
            string imagePath = xmlNode.SelectSingleNode("Graphics").SelectSingleNode("ImagePath").InnerText;
            string prefabPath = xmlNode.SelectSingleNode("Prefab").Attributes["src"].Value;
            FurniturePrototype prototype = new FurniturePrototype(name, imagePath);
            prototype.LvlImgColor = lvlImageColor32;
            prototype.prefabPath = prefabPath;
            prototype.hasCol = hasCol;
            prototype.hasRb = hasRb;

            FurniturePrototypes.Add(prototype);
            WorldImporter.FurnColorToProto.Add(lvlImageColor32, prototype);
        }
    }
}
