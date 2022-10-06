
using DungeonCrawl.Actors.Characters;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.scripts
{
    public class ArmorBar_Script : MonoBehaviour
    {
        public static Image ArmorBar;
        public static float CurrentArmor;
        public static float MaxArmor = 100f;
        Player Player;

        private void Start()
        {
            //Find
            ArmorBar = GetComponent<Image>();
            Player = FindObjectOfType<Player>();
            
        }
    }
}