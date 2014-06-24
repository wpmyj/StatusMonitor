using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MonitorApp.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required]
        [Display(Name = "账户名:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "请输入密码:")]
        //[DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "密码和确认密码不匹配。")]
        //[DataType(DataType.Password)]
        [Display(Name = "请再输入一次密码:")]
        public string ConfirmNewPassword { get; set; }
    }
}