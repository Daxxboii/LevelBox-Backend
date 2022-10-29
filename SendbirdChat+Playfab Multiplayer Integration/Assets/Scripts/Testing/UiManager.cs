using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public bool isDebug;

    void OnGUI()
    {
        if (isDebug)
        {
            if (GUI.Button(new Rect(20, 0, 150, 30), "Login as Daxx"))
            {
              //  PlayFabmanager.instance.SignUp("dhakaddaksh123@gmail.com", "Daksh123/","Daxx");
                 PlayFabmanager.instance.Login("dhakaddaksh123@gmail.com", "Daksh123/");
            }

            if (GUI.Button(new Rect(20, 50, 150, 30), "Login as MyBoy"))
            {
               // PlayFabmanager.instance.SignUp("MyBoy69@gmail.com", "MyBoy123","MyBoy");
                 PlayFabmanager.instance.Login("MyBoy69@gmail.com", "MyBoy123");
            }

            if (GUI.Button(new Rect(20, 100, 150, 30), "Login as JP00"))
            {
                //PlayFabmanager.instance.SignUp("jpGord00@gmail.com", "JP123/","JP00");
                PlayFabmanager.instance.Login("jpGord00@gmail.com", "JP123/");
            }

            if (GUI.Button(new Rect(20, 150, 150, 30), "Login as Other"))
            {


            }
        }
    }
}
