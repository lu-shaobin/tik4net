﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tik4net.Api;

namespace tik4net
{
    /// <summary>
    /// Factory to create and open mikrotik connection of given type.
    /// </summary>
    public static class ConnectionFactory
    {
        /// <summary>
        /// Creates mikrotik Connection of given type.
        /// </summary>
        /// <param name="connectionType">Type of technology used to connect to mikrotik router.</param>
        /// <returns>Instance of mikrotik Connection.</returns>
        /// <seealso cref="ITikConnection.Open(string, string, string)"/>
        public static ITikConnection CreateConnection(TikConnectionType connectionType)
        {
            switch (connectionType)
            {
                case TikConnectionType.Api:
                    return new ApiConnection(false, ApiConnection.LoginProcessVersion.Version1);
                case TikConnectionType.Api_v2:
                    return new ApiConnection(false, ApiConnection.LoginProcessVersion.Version2);
                case TikConnectionType.ApiSsl:
                    return new ApiConnection(true, ApiConnection.LoginProcessVersion.Version1);
                case TikConnectionType.ApiSsl_v2:
                    return new ApiConnection(true, ApiConnection.LoginProcessVersion.Version2);
                default:
                    throw new NotImplementedException(string.Format("Connection type '{0}' not supported.", connectionType));
            }
        }

        /// <summary>
        /// Creates and opens connection to the specified mikrotik host on default port and perform the logon operation.
        /// </summary>
        /// <param name="connectionType">Type of technology used to connect to mikrotik router.</param>
        /// <param name="host">The host (name or ip).</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Opened instance of mikrotik Connection.</returns>
        /// <seealso cref="ITikConnection.Close"/>
        public static ITikConnection OpenConnection(TikConnectionType connectionType, string host, string user, string password)
        {
            ITikConnection result = CreateConnection(connectionType);
            result.Open(host, user, password);

            return result;
        }

        /// <summary>
        /// Creates and opens connection to the specified mikrotik host on specified port and perform the logon operation.
        /// </summary>
        /// <param name="connectionType">Type of technology used to connect to mikrotik router.</param>
        /// <param name="host">The host (name or ip).</param>
        /// <param name="port">TCPIP port.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Opened instance of mikrotik Connection.</returns>
        /// <seealso cref="ITikConnection.Close"/>
        public static ITikConnection OpenConnection(TikConnectionType connectionType, string host, int port, string user, string password)
        {
            ITikConnection result = CreateConnection(connectionType);
            result.Open(host, port, user, password);

            return result;
        }

#if !(NET20 || NET35 || NET40)
        /// <summary>
        /// Creates and opens connection to the specified mikrotik host on default port and perform the logon operation.
        /// Async version.
        /// </summary>
        /// <param name="connectionType">Type of technology used to connect to mikrotik router.</param>
        /// <param name="host">The host (name or ip).</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Opened instance of mikrotik Connection.</returns>
        /// <seealso cref="ITikConnection.Close"/>
        public static async System.Threading.Tasks.Task<ITikConnection> OpenConnectionAsync(TikConnectionType connectionType, string host, string user, string password)
        {
            ITikConnection result = CreateConnection(connectionType);
            await result.OpenAsync(host, user, password);

            return result;
        }

        /// <summary>
        /// Creates and opens connection to the specified mikrotik host on specified port and perform the logon operation.
        /// Async version.
        /// </summary>
        /// <param name="connectionType">Type of technology used to connect to mikrotik router.</param>
        /// <param name="host">The host (name or ip).</param>
        /// <param name="port">TCPIP port.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Opened instance of mikrotik Connection.</returns>
        /// <seealso cref="ITikConnection.Close"/>
        public static async System.Threading.Tasks.Task<ITikConnection> OpenConnectionAsync(TikConnectionType connectionType, string host, int port, string user, string password)
        {
            ITikConnection result = CreateConnection(connectionType);
            await result.OpenAsync(host, port, user, password);

            return result;
        }
#endif
    }
}
