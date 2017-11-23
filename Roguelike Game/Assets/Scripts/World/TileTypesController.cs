using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

// A lot in common with the Furniture Controller. Should we make XMLImporter an abstract class?
public class TileTypesController : MonoBehaviour {

    public string TileTypesFileName = "Data/TileTypes.xml";

    public List<TileType> TileTypes { get; private set; }


    private void Awake()
    {
        //ReadTileTypes();
    }

    private void ReadTileTypes()
    {
        Debug.Log("Reading all TileTypes from " + TileTypesFileName);
        TileTypes = new List<TileType>();
        XmlDocument xmlDoc = new XmlDocument();
        string filePath = Path.Combine(Application.streamingAssetsPath, TileTypesFileName);
        if (filePath.Contains("://"))
            throw new XmlException("How the actual f*ck did you manage to run this on Web/Mobile/Not Standalone?");
        xmlDoc.Load(filePath);
        int id = 0;
        foreach (XmlNode xmlNode in xmlDoc.DocumentElement)
        {
            /// TODO: This is not scalable! Is there a better way to do this?
            // For each furniture listed, get its information
            string name = xmlNode.Attributes["name"].Value;
            Color lvlImageColor = Color.black;
            ColorUtility.TryParseHtmlString(xmlNode.SelectSingleNode("LvlImgColor").InnerText, out lvlImageColor);
            Color32 lvlImageColor32 = (Color32)lvlImageColor;
            // Furniture.Graphics.ImagePath - TODO: Handle more complicated graphics
            string imagePath = xmlNode.SelectSingleNode("Graphics").SelectSingleNode("ImagePath").InnerText;
            TileType type = new TileType(name, id);
            type.LvlImgColor = lvlImageColor32;

            TileTypes.Add(type);
            //WorldImporter.FurnColorToProto.Add(lvlImageColor32, prototype);
            id++;
        }
    }
}
