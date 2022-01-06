﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSweb.Models
{
    public class Student
    {
        [Key]
        [Required]
        [Display(Name = "學生編號")]
        public string SID { get; set; }

        [Required]
        [Display(Name = "學生姓名")]
        public string SName { get; set; }

        [Required]
        [Display(Name = "年級")]
        public string Grade { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string SPassword { get; set; }

        [Required]
        [Display(Name = "性別")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "教育階段")]
        public string Stage { get; set; }

        [Display(Name = "積分")]
        public string Score { get; set; }

        [Required]
        [Display(Name = "課程編號")]
        public string CID { get; set; }    
        public string GID { get; set; }

        public virtual Group group{ get; set; }
        public virtual Course course { get; set; }
        public virtual ICollection<StudentMission> StudentMissions { get; set; }
    }
}