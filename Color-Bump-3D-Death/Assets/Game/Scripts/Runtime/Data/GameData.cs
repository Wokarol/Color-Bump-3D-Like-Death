using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    /// <summary>
    /// Holds values about current session
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Global Game Data
        /// </summary>
        public static GameData Default = new GameData();

        /// <summary>
        /// Represents how far player went in the stage
        /// </summary>
        public float Progress { get; set; }
    } 
}
