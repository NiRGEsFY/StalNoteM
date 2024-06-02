using Microsoft.EntityFrameworkCore;
using StalNoteM.Data.DataItem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StalNoteM.Data.Users
{

    [PrimaryKey(nameof(Id))]
    public class UserCase
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name="Название")]
        public string Name { get; set; }


        [Display(Name ="Case Id")]
        public int? CaseId { get; set; }

        public CaseItem CaseItem { get; set; }


        public int? FirstArtefactQuality { get; set; }
        public double? FirstArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? FirstArtefactAddition { get; set; }
        public int? FirstArtefactId {  get; set; }
        public ArtefactItem? FirstArtefact { get; set; }


        public int? SecondArtefactQuality { get; set; }
        public double? SecondArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? SecondArtefactAddition { get; set; }
        public int? SecondArtefactId { get; set; }
        public ArtefactItem? SecondArtefact { get; set; }


        public int? ThirdArtefactQuality { get; set; }
        public double? ThirdArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? ThirdArtefactAddition { get; set; }
        public int? ThirdArtefactId { get; set; }
        public ArtefactItem? ThirdArtefact { get; set; }


        public int? ForthArtefactQuality { get; set; }
        public double? ForthArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? ForthArtefactAddition { get; set; }
        public int? ForthArtefactId { get; set; }
        public ArtefactItem? ForthArtefact { get; set; }


        public int? FifthArtefactQuality { get; set; }
        public double? FifthArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? FifthArtefactAddition { get; set; }
        public int? FifthArtefactId { get; set; }
        public ArtefactItem? FifthArtefact { get; set; }


        public int? SixthArtefactQuality { get; set; }
        public double? SixthArtefactPercent { get; set; }
        [MaxLength(3)]
        public string? SixthArtefactAddition { get; set; }
        public int? SixthArtefactId { get; set; }
        public ArtefactItem? SixthArtefact { get; set; }
    }
}
