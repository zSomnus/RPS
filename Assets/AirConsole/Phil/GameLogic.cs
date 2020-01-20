using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    string choice;

    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
    }

    void OnMessage(int device_id, JToken data)
    {
        Debug.Log($"Received message from {device_id}.\nMessage = {data}");

        if (data.ToString().Equals("fox"))
        {
            Camera.main.backgroundColor = new Color(0, 0, 255);
            choice = data.ToString();
        }

        else if (data.ToString().Equals("chicken"))
        {
            Camera.main.backgroundColor = new Color(0, 255, 0);
            choice = data.ToString();
        }

        else if (data.ToString().Equals("viper"))
        {
            Camera.main.backgroundColor = new Color(255, 0, 0);
            choice = data.ToString();
        }

        if (data.ToString().Equals("accepted"))
        {
            Debug.Log($"Player {device_id} chooses {choice}");
        }
    }

    void OnConnect(int device_id)
    {
        Debug.Log($"Device {device_id} has connected.");
    }

    void OnDisconnect(int device_id)
    {
        Debug.Log($"Device {device_id} has disconnected.");
    }
}
