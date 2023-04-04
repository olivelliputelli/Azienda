using Microsoft.EntityFrameworkCore;

namespace Azienda.Shared
{
    [Keyless]
    public class ImpiegatoEta
    {
        public int Matricola { get; set; }
        public string Nominativo { get; set; }
        public DateTime  DataDiNascita{ get; set; }
        public int Eta { get; set; }

    }
}