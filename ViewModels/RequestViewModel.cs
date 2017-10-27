using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using dz.SoftwareRequest.Models;

namespace  dz.SoftwareRequest.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Document No")]
        public string DocNo { get; set; }
        public string RequestBy { get; set; }
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Decription")]
        public string Description { get; set; }
        public DateTime? RequestDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate {get;set;}
        public DevelopTask Development {get;set;}
        public DevelopTask CodeReview { get; set; }
        public DevelopTask Security { get; set; }
        public DevelopTask UAT { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.New;
    }
}