// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerConfigurationSection.cs" company="Impendium">
//   ==============================================================================================
//   //  Impendium
//   //  Copyright (c) 2015, Impendium Corporation. All Rights Reserved.
//   //  Warning: This computer program is protected by copyright law and international treaties.
//   //  Unauthorised reproduction or distribution of this program, or any portion of it, may result
//   //  in severe civil and criminal penalties, and will be prosecuted to the maximum extent
//   //  possible under law.
//   // ==============================================================================================
// </copyright>
// <summary>
//   The server configuration section.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AutomationUtilities.Utils
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The server configuration section.
    /// </summary>
    public class ServerConfigurationSection : ConfigurationSection
    {
        // Create a "URL element."
        /// <summary>
        /// Gets or sets a value indicating URL.
        /// </summary>
        [ConfigurationProperty("url")]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }

            set
            {
                this["url"] = value;
            }
        }

        // Create a "resultsDB element."
        /// <summary>
        /// Gets or sets a value indicating resultsDB conn string.
        /// </summary>
        [ConfigurationProperty("resultsDB")]
        public ConnectionStringSettings ResultsDB
        {
            get
            {
                return (ConnectionStringSettings)this["resultsDB"];
            }

            set
            {
                this["resultsDB"] = value;
            }
        }
        // Create a "ICE_DB element."
        /// <summary>
        /// Gets or sets a value indicating ICE_DB conn string.
        /// </summary>
        [ConfigurationProperty("ICE_DB")]
        public ConnectionStringSettings IceDB
        {
            get
            {
                return (ConnectionStringSettings)this["ICE_DB"];
            }

            set
            {
                this["ICE_DB"] = value;
            }

        }

    }
}