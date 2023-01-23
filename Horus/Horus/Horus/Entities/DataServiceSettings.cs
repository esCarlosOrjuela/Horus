using System;
using System.Collections.Generic;
using Horus.Interfaces;

namespace Horus.Entities
{
    /// <summary>
    /// Class that represents the basic configuration to provide the synchronization service
    /// </summary>
    /// <reference>
    /// Autor: Carlos.Orjuela | 23.Jan.2023
    /// </reference>
    public class DataServiceSettings
    {
        #region Singleton
        private DataServiceSettings() { }
        private static DataServiceSettings _instance = null;
        public static DataServiceSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataServiceSettings();
                    _instance.ConfigurationParameters = new ConfigurationParameters();
                }
                return _instance;
            }
        }
        #endregion


        /// <summary>
        /// Property that gets or sets the basic information to provide the synchronization service
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public IDataService DataServices { get; set; }

        /// <summary>
        /// Property that gets or sets the basic configuration for accessing the synchronization service
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public ConfigurationParameters ConfigurationParameters { get; set; }


    }
}

