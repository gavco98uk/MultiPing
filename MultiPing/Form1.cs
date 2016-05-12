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
using System.Diagnostics;


namespace multiPing
{
    public partial class Form1 : Form
    {
        static public Label[] ipLabel;
        static public Label[] pingLabel;
        static public string[] pingResult;
        static public bool pingComplete;

        public Form1()
        {
            InitializeComponent();

            ipLabel = new Label[256];
            pingLabel = new Label[256];
            pingResult = new string[256];

            showIPlabels();
            showPingLabels();

            timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        	lblStatus.Text = "Sending ping requests...";
        	Thread thread = new Thread(new ThreadStart(pingThread));
        	thread.Start();
        	
        	// all pings sent, start a timer, set to 10 seconds
            // this is only required because Win7 is lame and wont call 
            // the pingcallback on a timeout :S
            timeoutTimer.Start();
            lblStatus.Text = "Ping requests sent... awaiting replies";
        }
        
        private void pingThread()
        {

           
            pingComplete = false;
            
            for (int i = 0; i < 256; i++)
            {
					pingResult[i] = null;
                	pingIP(i);
                
            }
            
            
            
            
        }

        public void showIPlabels()
        {
            int acrossCount = 0;

            int x = 10;
            int y = 10;

            // creates a grid of labels showing the IP addresses

            this.SuspendLayout();
            
            for (int i = 0; i < 256; i++)
            {
                if (acrossCount == 20)
                {
                    x = 10;
                    y += 30;
                    acrossCount = 0;
                }

                ipLabel[i] = new Label();
                ipLabel[i].Left = x;
                ipLabel[i].Top = y;
                ipLabel[i].Visible = true;
                ipLabel[i].Enabled = true;
                ipLabel[i].Text = i.ToString();
                ipLabel[i].Width = 25;
                ipLabel[i].Height = 15;
                ipLabel[i].TextAlign = ContentAlignment.TopCenter;
                ipLabel[i].BackColor = Color.White;
                ipLabel[i].Click += new EventHandler(label_click);

                this.Controls.Add(ipLabel[i]);


                x += 30;
                
                acrossCount++;
                
            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        public void showPingLabels()
        {
            int acrossCount = 0;

            int x = 10;
            int y = 25;

            // creates a grid of labels showing the IP addresses

            this.SuspendLayout();

            for (int i = 0; i < 256; i++)
            {
                if (acrossCount == 20)
                {
                    x = 10;
                    y += 30;
                    acrossCount = 0;
                }

                pingLabel[i] = new Label();
                pingLabel[i].Left = x;
                pingLabel[i].Top = y;
                pingLabel[i].Text = "-";
                pingLabel[i].Width = 25;
                pingLabel[i].Height = 15;
                pingLabel[i].TextAlign = ContentAlignment.TopCenter;
                pingLabel[i].BackColor = Color.LightSteelBlue;

                this.Controls.Add(pingLabel[i]);


                x += 30;

                acrossCount++;

            }

            this.ResumeLayout();
            this.PerformLayout();
        }

        private void label_click(object sender, EventArgs e)
        {
            Label l = (Label)sender;


            string IP = IPpart1.Value.ToString() + ".";
            IP += IPpart2.Value.ToString() + ".";
            IP += IPpart3.Value.ToString() + ".";
            IP += l.Text;

            details d = new details(IP);
            d.ShowDialog();
        }

        public void pingIP(int IP)
        {
            AutoResetEvent waiter = new AutoResetEvent (false);
            string IPaddress = IPpart1.Value.ToString() + "." + IPpart2.Value.ToString() + "." + IPpart3.Value.ToString() + "." + IP;
            IPAddress IPa = IPAddress.Parse(IPaddress);
            
            Debug.WriteLine("Pinging " + IP.ToString());
            
            Ping ping = new Ping();
            ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            ping.SendAsync(IPa, waiter);
            
        }

        public  void updateScreen(int ipBlock)
        {

            pingLabel[ipBlock].Text = pingResult[ipBlock];

            if (pingResult[ipBlock] == "X")
                pingLabel[ipBlock].BackColor = Color.IndianRed;
            else if (pingResult[ipBlock] == null)
                pingLabel[ipBlock].BackColor = Color.LightSteelBlue;
                else
                pingLabel[ipBlock].BackColor = Color.DarkSeaGreen;

               
            

            
        }

        public  void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            

            PingReply reply = e.Reply;
                // get the IP that was pinged
                
                
                
                if(reply.Address.ToString() != "0.0.0.0")
                {
                	string[] IParray = reply.Address.ToString().Split('.');
	                int iIP = Int32.Parse(IParray[3]);
	                if (reply.Status == IPStatus.Success)
	                    pingResult[iIP] = reply.RoundtripTime.ToString();
	                else
	                    pingResult[iIP] = "X";
	            
	                Debug.WriteLine("Ping Reply From " + reply.Address.ToString() + " Time: " + pingResult[iIP] + " Status: " + reply.Status );
	
	                // check if the last ping (255) has been reveived and mark the ping complete flag if so
	                if (iIP == 255)
	                {
	                    pingComplete = true;
	                    lblStatus.Text = "Ping Complete";
	                }
                }
                
                
                
            ((AutoResetEvent)e.UserState).Set();
        }

        private void IPpart_SelectText(object sender, EventArgs e)
        {
            (sender as NumericUpDown ).Select(0, 3);
        }
        
        
        void Timer1Tick(object sender, EventArgs e)
        {
        	for(int i=0; i < 256; i++)
        		updateScreen(i);
        	
        	timer1.Start();
        }
        
        void TimeoutTimerTick(object sender, EventArgs e)
        {
        	// its 10 seconds since the last ping was sent, set any IP that hasnt replied yet to an x
        	for(int i=0; i< 256; i++)
        	{
        		if(pingResult[i] == null)
        		{
        			pingResult[i] = "X";
        		}
        	}
        	
        	lblStatus.Text = "Ping Complete";
        }
        

    }
}