using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HomeSceneManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerUsername;
    public TextMeshProUGUI PlayerClan;

    private void Start()
    {
        PlayerUsername.text = GameManager.PlayerUserName;
    }
}
