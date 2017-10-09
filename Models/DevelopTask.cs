using System;

namespace dz.SoftwareRequest.Models
{
    public class DevelopTask
    {
        public string ActionBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Manday { get; set; }
        public int Holiday { get; set; }
        public string Remark { get; set; }
        public string AttrachFile { get; set; }
    }
}