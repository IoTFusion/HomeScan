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
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class UsageItem : TableEntity
    {
        public UsageItem(string device)
        {
            this.RowKey = device;
        }

        public UsageItem() { }

        public string usage { get; set; }
    }

    public sealed partial class MainPage : Page
    {
        List<Devices> DeviceList;
        const string key = "DefaultEndpointsProtocol=https;AccountName=homescan;AccountKey=tYEu/GQ4cuLCQXACkCzXtRE+DzbiFzoQDb5oig6uQICCVPyY3wDW47VOvqWQlTIWThJOU0L1xNXiaBM2bGuJDA==;BlobEndpoint=https://homescan.blob.core.windows.net/;TableEndpoint=https://homescan.table.core.windows.net/;QueueEndpoint=https://homescan.queue.core.windows.net/;FileEndpoint=https://homescan.file.core.windows.net/";
        CloudTableClient tableClient;
        CloudTable table;
        TableBatchOperation batchOperation;
        public MainPage()
        {
            this.InitializeComponent();
            batchOperation = new TableBatchOperation();
            DeviceList = new List<Devices>();
            DispatcherTimer timer1 = new DispatcherTimer();
            timer1.Tick += Timer1_Tick;
            timer1.Interval = TimeSpan.FromSeconds(5);
            timer1.Start();
            DispatcherTimer timer2 = new DispatcherTimer();
            timer2.Tick += Timer2_tick;
            timer2.Interval = TimeSpan.FromSeconds(5);
            timer2.Start();
            CloudStorageAccount cloudstorage = CloudStorageAccount.Parse(key);
            tableClient = cloudstorage.CreateCloudTableClient();
            table = tableClient.GetTableReference("usagedata");

            string something = "something";
        }

        private async void Timer2_tick(object sender, object e)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            
               UsageItem device1 = new UsageItem( DeviceList.ElementAt(1).device);
            device1.usage = DeviceList.ElementAt(1).usage;
            UsageItem device2 = new UsageItem(DeviceList.ElementAt(2).device);
            device1.usage = DeviceList.ElementAt(2).usage;
            UsageItem device3 = new UsageItem(DeviceList.ElementAt(3).device);
            device1.usage = DeviceList.ElementAt(3).usage;
            UsageItem device4 = new UsageItem(DeviceList.ElementAt(4).device);
            device1.usage = DeviceList.ElementAt(4).usage;
            UsageItem device5 = new UsageItem(DeviceList.ElementAt(5).device);
            device1.usage = DeviceList.ElementAt(5).usage;
            UsageItem device6 = new UsageItem(DeviceList.ElementAt(6).device);
            device1.usage = DeviceList.ElementAt(6).usage;
            UsageItem device7 = new UsageItem(DeviceList.ElementAt(7).device);
            device1.usage = DeviceList.ElementAt(7).usage;
            UsageItem device8 = new UsageItem(DeviceList.ElementAt(8).device);
            device1.usage = DeviceList.ElementAt(8).usage;
            UsageItem device9 = new UsageItem(DeviceList.ElementAt(9).device);
            device1.usage = DeviceList.ElementAt(9).usage;
            UsageItem device10 = new UsageItem(DeviceList.ElementAt(10).device);
            device1.usage = DeviceList.ElementAt(10).usage;
            UsageItem device11 = new UsageItem(DeviceList.ElementAt(11).device);
            device1.usage = DeviceList.ElementAt(11).usage;
            UsageItem device12 = new UsageItem(DeviceList.ElementAt(12).device);
            device1.usage = DeviceList.ElementAt(12).usage;
            UsageItem device13 = new UsageItem(DeviceList.ElementAt(13).device);
            device1.usage = DeviceList.ElementAt(13).usage;
            UsageItem device14 = new UsageItem(DeviceList.ElementAt(14).device);
            device1.usage = DeviceList.ElementAt(14).usage;
            UsageItem device15 = new UsageItem(DeviceList.ElementAt(15).device);
            device1.usage = DeviceList.ElementAt(15).usage;

            

            batchOperation.Insert(device1);
            batchOperation.Insert(device2);
            batchOperation.Insert(device3);
            batchOperation.Insert(device4);
            batchOperation.Insert(device5);
            batchOperation.Insert(device6);
            batchOperation.Insert(device7);
            batchOperation.Insert(device8);
            batchOperation.Insert(device9);
            batchOperation.Insert(device10);
            batchOperation.Insert(device11);
            batchOperation.Insert(device12);
            batchOperation.Insert(device13);
            batchOperation.Insert(device14);
            batchOperation.Insert(device15);

            await table.ExecuteBatchAsync(batchOperation);
        }

        private void Timer1_Tick(object sender, object e)
        {
            DeviceList.Clear();
            int ison, i=0;
            double usage;
            Random rnd = new Random();
            string onText;
            string DevName;
            for (i = 0; i < 15; i++)
            {
                DevName = "Device " + i.ToString();
                ison = rnd.Next(1, 3);
                if (ison != 1)
                {
                    usage = rnd.NextDouble();
                    usage++;
                    usage *= 10;
                    onText = "on";
                }
                else
                {
                    usage = 0;
                    onText = "off";

                }
                DeviceList.Add(new Devices { device = DevName, status = onText, usage = usage.ToString("0.00") + "kW" });
            }

        }
    }
}
