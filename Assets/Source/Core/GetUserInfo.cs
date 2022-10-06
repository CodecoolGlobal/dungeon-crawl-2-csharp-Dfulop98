using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GetUserInfo
{ 
    public class GetUserInfo : MonoBehaviour
    {
        public Button ClassName;
        public TMP_InputField PlayerName;

        public void GetInfo()
        {
            UserInfo.UserName = PlayerName.text;
            UserInfo.UserClass = ClassName.name;
            

            SceneManager.LoadScene("Game");
        }

    }

    public static class UserInfo
    {
        public static string UserName { get; set; }
        public static string UserClass { get; set; }
    }

}