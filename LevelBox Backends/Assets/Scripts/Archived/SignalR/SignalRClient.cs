using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using TMPro;
using MyBox;
using PlayFab.Json;
using System.Drawing;

public class SignalRClient : MonoBehaviour 
{
    // SignalR variables
   /* private static Uri uri = new Uri("https://localhost:7213/GameHub");

    public static SignalRClient instance;

    private HubConnection connection;

    public string SignalRID;

    //  Use this for initialization
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
        Connect();
    }



    // Connect to the SignalR server
    public async void Connect()
    {
       connection = new HubConnectionBuilder().WithUrl(uri).Build();

       await connection.StartAsync();
    
        //Map Data to Functions
        MapDataToFunctions();

        //Replacing "Group" with Clan Name 
        await connection.InvokeAsync<string>("AddToGroup", "Group");
        await connection.InvokeAsync<string>("SendSignalRIDToClient");

        Debug.Log("SignalR Connected");
    }

    void MapDataToFunctions()
    {
        #region Testing 
        //On Recieving Public Data
        connection.On<string>("Data", (data) =>
        {
            dynamic DeserializedData = JsonConvert.DeserializeObject(data);
            dynamic NestedEventData = JsonConvert.DeserializeObject(DeserializedData.PlayStreamEventEnvelope.EventData.ToString());

            Debug.Log(DeserializedData);
        });

        //On Recieving Private Data
        connection.On<string>("PrivateData", (data) =>
        {
            dynamic DeserializedData = JsonConvert.DeserializeObject(data);
            dynamic NestedEventData = JsonConvert.DeserializeObject(DeserializedData.PlayStreamEventEnvelope.EventData.ToString());

            Debug.Log(DeserializedData);
        });

        //On Recieving Group Data
        connection.On<string>("PrivateGroupData", (data) =>
        {
            dynamic DeserializedData = JsonConvert.DeserializeObject(data);
            dynamic NestedEventData = JsonConvert.DeserializeObject(DeserializedData.PlayStreamEventEnvelope.EventData.ToString());

            Debug.Log(DeserializedData);
        });
        #endregion

        //On Receiving SignalR ID
        connection.On<string>("SignalRID", (data) =>
        {
            SignalRID = data;
        });


        //On Blocks Received
        connection.On<string>("DonateBlocks", (data) =>
        {
            dynamic DeserializedData = JsonConvert.DeserializeObject(data);
            //pull block data from DeserializedData and add to inventory
            Debug.Log(DeserializedData);
        });

        //On Block Request Received
        connection.On<string>("RequestBlocks", (data) =>
        {
            dynamic DeserializedData = JsonConvert.DeserializeObject(data);
            //Show the request to player

            //call DonateBlock() if player clicks on Donate
            Debug.Log(DeserializedData);
        });

    }

   
    //If Player Requests a Block
    public async void RequestBlock(string BlockData)
    {
        await connection.InvokeAsync<string>("RequestBlocks", BlockData);
        //Update UI
    }

    //If Player Donates a Block
    public async void DonateBlock(string BlockData)
    {
        await connection.InvokeAsync<string>("DonateBlocks", BlockData);

        //Remove the blocks from inventory
    }

    

    private async void OnApplicationQuit()
    {
        await connection.InvokeAsync<string>("RemoveFromGroup", "Group");
        await connection.StopAsync();
    }*/
}
