using System;

namespace Project_SignalR_Api2.Models
{
    public enum Ecity   //enum:değerleri karşılıklarıyla tutan yapı. sabit özellikler. şehirlerde sabit olanları burda yazıcaz.
    {
        istanbul = 1,
        ankara = 2,
        izmir = 3,
        konya = 4,
        trabzon = 5
    }
    public class Electric
    {
        public int ElectricID { get; set; }
        public Ecity City { get; set; }
        public int Count { get; set; }
        public DateTime ElectricDate { get; set; }
    } 
}
