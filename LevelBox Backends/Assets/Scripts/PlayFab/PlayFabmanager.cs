using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class PlayFabmanager : MonoBehaviour
{
    public static PlayFabmanager instance;
    string encryptedPassword;

    private void Awake()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(this);
    }

    #region Signup and Login

    string Encrypt(string StringToEncrypt)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] bs = System.Text.Encoding.UTF8.GetBytes(StringToEncrypt);

        bs = x.ComputeHash(bs);
        System.Text.StringBuilder s = new System.Text.StringBuilder();

        foreach(byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    public void SignUp(string Email , string Password,string Username )
    {
        // Debug.Log(username.text);
        var registerRequest = new RegisterPlayFabUserRequest { Email = Email, Password = Encrypt(Password), Username = Username };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterFailure);
    }

    void RegisterSuccess(RegisterPlayFabUserResult result)
    {
      
        GameManager.PlayerUserName = result.Username;
        SceneManager.LoadScene("Connect");
    }

    void RegisterFailure(PlayFabError error)
    {
       
        Debug.Log(error);
    }

    public void Login(string Email, string Password)
    {
        var request = new LoginWithEmailAddressRequest { Email = Email, Password = Encrypt(Password), InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
        {
            GetPlayerProfile = true
        }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, loginFailure);
    }
    void loginFailure(PlayFabError error)
    {
      
        Debug.Log(error);
    }

    void LoginSuccess(LoginResult login)
    {
        GameManager.PlayerUserName =  login.InfoResultPayload.PlayerProfile.DisplayName;
        SceneManager.LoadScene("Connect");
    }
    #endregion

    #region Save And Load
    public void SaveData()
    {
        var request = new UpdateUserDataRequest
        {
           // Data = Any Custom Dictionary
        };

        PlayFabClientAPI.UpdateUserData(request, result => Debug.Log("Data Saved"), error => Debug.LogError(error.GenerateErrorReport()));
    }

   

    public void LoadData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result => Debug.Log("Data Loaded"), error => Debug.LogError(error.GenerateErrorReport()));
    }

    #endregion

    #region Custom Events to Trigger Playfab Functions

    public void SendEventToAll(string PlayerSignalRID,string DataType,string DataValue)
    {
        PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest {
            EventName = "SendToAll",
             Body = new Dictionary<string, object> {
            { DataType,DataValue},
            { "SignalRID", PlayerSignalRID}}}

        ,result=> Debug.Log("Event Called"),error=> Debug.LogError(error.GenerateErrorReport()));
     
    }

    public void SendEventToGroup(string PlayerSignalRID,string GroupName,string DataType, string DataValue)
    {
        PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest
        {
            EventName = "SendToGroup",
            Body = new Dictionary<string, object> {
            { DataType, DataValue },
            { "SignalRID", PlayerSignalRID},
            { "GroupName", GroupName} }
        }
        , result => Debug.Log("Event Called"), error => Debug.LogError(error.GenerateErrorReport()));

    }
    public void SendEventToPrivatePlayer(string PlayerSignalRID,string DataType, string DataValue)
    {
        PlayFabClientAPI.WritePlayerEvent(new WriteClientPlayerEventRequest
        {
            EventName = "SendToPlayer",
            Body = new Dictionary<string, object> {
            { DataType, DataValue },
            { "SignalRID",PlayerSignalRID}}
        }
        , result => Debug.Log("Event Called"), error => Debug.LogError(error.GenerateErrorReport()));

    }


    #endregion

}
