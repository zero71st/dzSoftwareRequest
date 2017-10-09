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
        [DisplayName("Document No:")]
        public string DocNo { get; set; }
        [DisplayName("Request By:")]
        public string RequestBy { get; set; }
        [DisplayName("Title:")]
        public string Title { get; set; }
        [DisplayName("Decription:")]
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovedRequestBy { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.New;
    }
}