
using DungeonCrawl.Actors.Characters;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.scripts
{
    public class HealthBar_Script : MonoBehaviour
    {
        public static Image HealthBar;
        public static float CurrenctHealth;
        public static float MaxHealth = 100f;
        Player Player;

        private void Start()
        {
            //Find
            HealthBar = GetComponent<Image>();
            Player = FindObjectOfType<Player>();
        }

        

    }
}