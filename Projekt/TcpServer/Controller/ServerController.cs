using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;

using TcpServer.View;
using TcpServer.Model;
using System.Data;
using System.Data.SqlClient;

namespace TcpServer.Controller
{

    public class ServerController
    {
        IServerView _view;

        Server server;

        public ServerController(IServerView view)
        {
            _view = view;
            view.SetController(this);
        }


        public string GetLocalIpAddress()
        {
            UnicastIPAddressInformation mostSuitableIp = null;

            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var network in networkInterfaces)
            {
                if (network.OperationalStatus != OperationalStatus.Up)
                    continue;

                var properties = network.GetIPProperties();

                if (properties.GatewayAddresses.Count == 0)
                    continue;

                foreach (var address in properties.UnicastAddresses)
                {
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    if (!address.IsDnsEligible)
                    {
                        if (mostSuitableIp == null)
                            mostSuitableIp = address;
                        continue;
                    }

                    // The best IP is the IP got from DHCP server
                    if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                    {
                        if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                            mostSuitableIp = address;
                        continue;
                    }

                    return address.Address.ToString();
                }
            }

            return mostSuitableIp != null
                ? mostSuitableIp.Address.ToString()
                : "";
        }

        public void StartListener(string ipAddressTextbox, string portTextBox)
        {

            server = new Server(ipAddressTextbox, int.Parse(portTextBox));
            server.startListing();
            server.OnclientConnected += new Server.PropertyChangeHandler(server_OnclientConnected);
            _view.Label3 = "Server is up and running";
            server.ConnectDataBase();

        }


        public void server_OnclientConnected(object sender, EventArgs args)
        {
            User usr = (User)sender;
            _view.AddPlayer(usr);
        }

        // initialView
        public void LoadView()
        {
            _view.Label3 = "Server is not running";
            _view.IpAddressTextbox = GetLocalIpAddress();
            _view.PortTextbox = "50100";
        }


    }
}
