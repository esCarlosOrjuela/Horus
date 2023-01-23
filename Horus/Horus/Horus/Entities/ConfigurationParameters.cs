using System;
using System.Collections.Generic;

namespace Horus.Entities
{
    /// <summary>
    /// Class that represents the basic configuration to access a service
    /// </summary>
    /// <reference>
    /// Autor: Carlos.Orjuela | 23.Jan.2023
    /// </reference>
    public class ConfigurationParameters
    {
        /// <summary>
        /// HTTP defines a set of request methods to indicate the action to be performed for a given resource.
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public enum TypeHttMethod
        {
            POST,
            GET,
            UPDATE,
            DELETE
        }

        /// <summary>
        /// Property that gets or sets the connection point, to exchange information over the network
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public string UrlWebServices { get; set; }

        /// <summary>
        /// Property that gets or sets the request HTTP method to indicate the action to be performed for a given resource
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public TypeHttMethod HttMethod { get; set; }

        /// <summary>
        /// The header specifies information about the host, the web server software used by the end client, what the client's user agent is, etc.
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public Dictionary<string, string> RequestHeaders { get; set; }

    }
}

