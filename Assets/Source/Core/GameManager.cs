using Assets.Source.Core;
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

            MapLoader.LoadMap(1);
            Debug.Log(UserInfo.UserName);
            Debug.Log(UserInfo.UserClass);
            
            MapLoader.LoadMap("map_1", true);
            MapLoader.LoadMap("map_1", false);

        }
    }
}
