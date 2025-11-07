using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_Lab3_DiceGame_Cadelinia_Demi.Scripts
{
    internal class Dungeon
    {
        int mapSize = 3;
        public int MapSize => mapSize;
       
        public Dungeon() 
        { 
            VisualizeMap();
        }
        private void VisualizeMap()
        {
            for (int x = 0; x < mapSize; x++)
            {
                for (int z = 0; z < mapSize; z++)
                {
                    // using primitives for now, will replace next week
                    var mapRoomRepresentation = GameObject.CreatePrimitive
                        (PrimitiveType.Cube);
                    mapRoomRepresentation.transform.position = new Vector3(x, 0, z);
                }
            }
        }
    }
}