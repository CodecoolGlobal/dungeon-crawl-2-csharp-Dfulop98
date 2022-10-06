using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetUserInfo : MonoBehaviour
{
    public Button ClassName;
    public TMP_InputField PlayerName;

    public void GetInfo()
    {
        
        Debug.Log(ClassName.name);
        Debug.Log(PlayerName.text);
    }

    
}
