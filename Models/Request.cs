using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace dz.SoftwareRequest.Models
{
    public class Request    
    {
        public int Id { get; set; }
        public string DocNo { get; set; }
        public string RequestBy { get; set; }
        public string Title { get; set; }           
        [MaxLength(5000)]
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovedBy { get; set; }
        public string MeetingDate {get;set;}
        public string MeetingRemark { get; set; }
        public DevelopTask Development { get; set; }
        public DevelopTask SecurityTest { get; set; }
        public DevelopTask CodeReview { get; set; }
        public DevelopTask UAT { get; set; }
        public DevelopTask Deployment {get;set;}
        public string ApprovedProjectBy { get; set; }
        public RequestStatus Status { get; set; }
    }
}