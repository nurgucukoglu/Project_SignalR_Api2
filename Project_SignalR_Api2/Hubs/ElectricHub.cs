using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Project_SignalR_Api2.Hubs
{
    public class ElectricHub :Hub
    {
        private readonly ElectricService _service;
        public ElectricHub(ElectricService service)
        {
            _service = service;
        }


        public async Task GetElectricList() //invoke ile çağırılacak: getelc., connection ile bağlanılacak: receiveelc.
        {
            await Clients.All.SendAsync("ReceiveElectricList", _service.GetElectricChartsList());
        }
    }
}
