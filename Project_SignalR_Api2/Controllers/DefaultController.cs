using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_SignalR_Api2.Hubs;
using Project_SignalR_Api2.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Project_SignalR_Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ElectricService _service;
        public DefaultController(ElectricService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SaveElectric(Electric electric)  //bu post işlemiyle postmanda elect verisini manuel olarak giricez.
        {
            await _service.SaveElectric(electric);
           // IQueryable<Electric> electricList = _service.GetList();
            return Ok(_service.GetElectricChartsList());
        }

        [HttpGet]
        public IActionResult SendData()  //Her sn.de bir kez db.ye enumdan gelen değerlerle beraber her şehre 1 tane, toplamda 10 tane 100 ile 1000 arasında rastgele bir birim değeri kaydedicek(watt vs diyebiliriz.
        {
            Random rnd = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x => //range aralık sağlar
            {
                foreach (Ecity item in Enum.GetValues(typeof(Ecity)))
                {
                    var newElectric = new Electric
                    {
                        City = item,
                        Count = rnd.Next(100, 1000),
                        ElectricDate = DateTime.Now.AddDays(x) //x: range.in değerlerini alıcak
                    };
                    _service.SaveElectric(newElectric).Wait(); 
                    System.Threading.Thread.Sleep(1000);  //bu işlemler 1 sn arayla gerçekleşecek.
                }
            });
            return Ok("Elektrik verileri veri tabanına kaydedildi");  //5 tane şehir var: 1.sn de 1.tarih için; istanbul da verileri kaydetti
                                                                      // ankara, izmir.. 2.tarih için de ist ankara, izmir.. bunu 10 kere tekrarlıcak. % şehir var her biri 1 sn. Toplam işlem 50 sn, db.de toplam 50 veri olmalı. 
        }


    }
}
