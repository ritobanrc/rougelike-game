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
            // Furniture.Graphics.ImagePath - TODO: Handle more complicated graphics
            string imagePath = xmlNode.SelectSingleNode("Graphics").SelectSingleNode("ImagePath").Value;
            FurniturePrototype prototype = new FurniturePrototype(name, imagePath);
            Color lvlImageColor = Color.black;
            ColorUtility.TryParseHtmlString(xmlNode.SelectSingleNode("LvlImgColor").Value, out lvlImageColor);
            Color32 lvlImageColor32 = (Color32)lvlImageColor;
            prototype.LvlImgColor = lvlImageColor32;

            FurniturePrototypes.Add(prototype);
            WorldImporter.lvlImageColorToFurniturePrototype.Add(lvlImageColor32, prototype);
        }
    }
}
