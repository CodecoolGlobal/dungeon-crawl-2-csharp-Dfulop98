using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using Assets.Source.Actors.Items;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="mapName"></param>
        public static void LoadMap(string mapName, bool isStatic)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"{mapName}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];
                    if (isStatic)
                    {
                        SpawnStaticActors(character, (x, -y));
                    }
                    else
                    {
                        SpawnDynamicActor(character, (x, -y));
                    }
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 10;
            
        }

        public static void SpawnStaticActors(char c, (int x, int y) position)
        {
            switch (c)
            {
                //map sprites 
                //TODO: find something shorter for this
                case 'g':
                    ActorManager.Singleton.Spawn<Water9>(position);
                    break;
                case 'h':
                    ActorManager.Singleton.Spawn<Water8>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Water7>(position);
                    break;
                case 'z':
                    ActorManager.Singleton.Spawn<Water6>(position);
                    break;
                case 'y':
                    ActorManager.Singleton.Spawn<Water5>(position);
                    break;
                case 'x':
                    ActorManager.Singleton.Spawn<Water4>(position);
                    break;
                case 'c':
                    ActorManager.Singleton.Spawn<Water3>(position);
                    break;
                case 'v':
                    ActorManager.Singleton.Spawn<Water2>(position);
                    break;
                case 'b':
                    ActorManager.Singleton.Spawn<Water1>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<SandFloor>(position);
                    break;
                case 'D':
                    ActorManager.Singleton.Spawn<WoodenFloor>(position);
                    ActorManager.Singleton.Spawn<Door>(position);
                    break;
                case 'r':
                    ActorManager.Singleton.Spawn<WoodenFloor>(position);
                    break;
                
                case 'w':
                    ActorManager.Singleton.Spawn<WoodenFloor>(position);
                    ActorManager.Singleton.Spawn<StoneWall>(position);
                    break;
                case 'T':
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    ActorManager.Singleton.Spawn<MapTree>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<GrassFloor>(position);
                    break;
            }
        }

        public static void SpawnDynamicActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                //player
                // TODO handle class choice and spawn accordingly
                case 'p':
                    ActorManager.Singleton.Spawn<Wizard>(position);
                    CameraController.Singleton.Position = position;
                    break;

                //mobs
                case 'a':
                    ActorManager.Singleton.Spawn<Minotaur>(position);
                    break;
                case 'q':
                    ActorManager.Singleton.Spawn<Slime>(position);
                    break;
                case 'Y':
                    ActorManager.Singleton.Spawn<Mushroom>(position);
                    break;
              
                //items
                // TODO handle class choice and spawn items accordingly
                case 'K':
                    ActorManager.Singleton.Spawn<Key>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Stick>(position);
                    break;
                case 'e':
                    ActorManager.Singleton.Spawn<Blanket>(position);
                    break;
                case ',':
                    ActorManager.Singleton.Spawn<HealthPotion>(position);
                    break;
                case 'G':
                    ActorManager.Singleton.Spawn<Wand>(position);
                    break;

            }
        }
    }
}
