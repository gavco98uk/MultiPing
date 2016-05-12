/*
Copyright (c) 2016 Gavin Coates  

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
	
namespace multiPing
{
    public partial class details : Form
    {
        IPAddress IP;


        public details(string IP)
        {
            InitializeComponent();
            this.IP = IPAddress.Parse(IP);
            lblIP.Text = IP.ToString();  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void startPing(IPAddress IP)
        {
            
            
            textStatus.Text += "Pinging " + IP.ToString() + "...";
            this.Refresh();

            Ping ping = new Ping();

            PingReply reply = ping.Send(IP);
            if (reply.Status == IPStatus.Success)
                textStatus.Text += " Time: " + reply.RoundtripTime.ToString() + "\r\n";
            else
                textStatus.Text += reply.Status.ToString() + "\r\n";
        }

        private void details_Shown(object sender, EventArgs e)
        {
            startPing(this.IP);
            startPing(this.IP);
            startPing(this.IP);
            startPing(this.IP);
            startPing(this.IP);
        }


        /*
        public void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {


            PingReply reply = e.Reply;
            // get the IP that was pinged
            string IP = reply.Address.ToString();
            string[] IParray = IP.Split('.');
            int iIP = Int32.Parse(IParray[3]);
            if (reply.Status == IPStatus.Success)
                textStatus.Text += " Time: " + reply.RoundtripTime.ToString() + "\n";
            else
                textStatus.Text += reply.Status.ToString();


            
        }
         * */
    }
}