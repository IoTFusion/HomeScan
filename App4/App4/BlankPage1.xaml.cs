using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        DispatcherTimer timer1;
        DispatcherTimer timer2;
        List<AllDevice> AllList = new List<AllDevice>();
        List<ONItem> ONList = new List<ONItem>(); 
        string[] Devices = new string[20];
        string thisName;
        public BlankPage1()
        {
            this.InitializeComponent();
            
            timer2 = new DispatcherTimer();
            timer2.Tick += Ontimer2Tick;
            timer2.Interval = TimeSpan.FromSeconds(5);
            int count;
            for(count = 0; count<20;count++)
            {
                Devices[count] = "Device" + (count + 1).ToString();
            }
            timer2.Start();
            
        }

        private void Ontimer2Tick(Object sender, Object e)
        {
            AllList.Clear();
            ONList.Clear();
            int randomnumber1, count=0, rndHelp;
            string[] randomnumber2 = new string[20];
            string[] Col = new string[20];
            double full=0;
            string[] sTatus = new string[20];
            Random rnd = new Random();
            while(count<20)
            {
                randomnumber1 = rnd.Next(1,3);
                if(randomnumber1==1)
                {
                    rndHelp = rnd.Next(100, 400);
                    sTatus[count] = "OFF";
                    Col[count] = "Red";
                    randomnumber2[count] = rndHelp.ToString() + "mA";
                    full += (rndHelp / 1000);
                    AllList.Add(new AllDevice {Device = Devices[count], Usage = randomnumber2[count], Status=sTatus[count]});

                }
                else
                {
                    rndHelp = rnd.Next(1, 10);
                    sTatus[count] = "ON";
                    Col[count] = "Green";
                    randomnumber2[count] = rndHelp.ToString() + "A";
                    full += rndHelp;
                    AllList.Add(new AllDevice { Device = Devices[count], Usage = randomnumber2[count], Status = sTatus[count]});
                    ONList.Add(new ONItem { Device = Devices[count] });
                }
                count++;
            }
            JustOn.ItemsSource = ONList;
            FullList.ItemsSource = AllList;
            FullNumber.Text = full.ToString("0.00") + "A";





        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlankPage2), null);
        }


        private void FullList_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*timer2.Stop();
            AllDevice thisDevice = e.ClickedItem as AllDevice;
            thisName = thisDevice.Device;
            Frame.Navigate(typeof(BlankPage2), thisName);*/
        }
    }
}
