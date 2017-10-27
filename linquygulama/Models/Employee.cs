using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linquygulama.Models
{
    public class Employee
    {
        //"Adi":"Mehmet","Soyad":"Tan","Sehir":"İzmir","DepartmanId":"1","SorumluId":"3",
        //"Dt":"10.10.1991","İseGirisTarihi":"10.10.2010","IstenCıkısTarihi":"10.10.2015"
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        public int DepartmanId { get; set; }
        public int? SorumluId { get; set; }
        public DateTime Dt { get; set; }
        public DateTime GirisTarih { get; set; }
        public DateTime CikisTarih { get; set; }

    }
}
