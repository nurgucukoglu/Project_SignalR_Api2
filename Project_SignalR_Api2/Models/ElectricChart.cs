using System.Collections.Generic;

namespace Project_SignalR_Api2.Models
{
    public class ElectricChart
    {
        public ElectricChart()
        {
            Counts = new List<int>();
        }
        public string ElectricDate { get; set; }
        public List<int> Counts { get; set; } // o tarihte consume edilen değer

    }
}
