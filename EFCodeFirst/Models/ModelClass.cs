using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCodeFirst.Models
{
        public enum ProjectTypes
        {
            Web = 1,
            Mobile = 2,
            Desktop=3
        }

        
        public class Client
        {
            [Key]
            public int ClientID { get; set; }
            public string ClientName { get; set; }
        }

        public class Project
        {
            [Key]
            public int ProjectID { get; set; }

            [Required]
            [DisplayName("Client Name")]
            public int ClientID { get; set; }

            [Required]
            [DisplayName("Project Name")]
            public string ProjectName { get; set; }

            [Required]
            [Column(TypeName = "text")]
            [DataType(DataType.MultilineText)]
            [DisplayName("Project Description")]
            public string ProjectDescription { get; set; }

            [DisplayName("Project Type")]
            public string ProjectType { get; set; }

            [NotMapped]
            [Range(1, int.MaxValue, ErrorMessage = "Select a type")]
            public ProjectTypes projectTypes { get; set; }
        
            public virtual Client Client { get; set; }
        }
    }