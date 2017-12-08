using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawner : MonoBehaviour
{
    private void Start()
    {
        Object player = Instantiate(Resources.Load("Player/Player"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        player.name = "Player";
        Object mainCamera = Instantiate(Resources.Load("Camera/Main Camera"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        mainCamera.name = "Main Camera";
        Object canvas = Instantiate(Resources.Load("Inventory/UICanvas"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        canvas.name = "UICanvas";
        Object UpdateManager = Instantiate(Resources.Load("Misc/UpdateManager"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        UpdateManager.name = "UpdateManager";
        Object EventSystem = Instantiate(Resources.Load("Inventory/EventSystem"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        EventSystem.name = "EventSystem";
        Object WorldImporter = Instantiate(Resources.Load("WorldGen/World Importer"), new Vector3(0f, 0f, 0f), Quaternion.identity);
        WorldImporter.name = "World Importer";
        GameObject.Destroy(this.transform.gameObject);
    }
}