using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using UnityEngine;
using GetUserInfo;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     Loads the initial map and can be used for keeping some important game variables
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {

            Debug.Log(UserInfo.UserName);
            Debug.Log(UserInfo.UserClass);
            
            MapLoader.LoadMap("map_1", true, UserInfo.UserClass);
            MapLoader.LoadMap("map_1", false, UserInfo.UserClass);
        }
    }
}
