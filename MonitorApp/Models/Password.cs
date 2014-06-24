using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MonitorApp.Models
{
    public class Password
    {
        public int PasswordId { get; set; }
        
        [Required]
        [Display(Name="账户名:")]
        public string Name { get; set; }

        //[Required]
        [Display(Name="请输入密码:")]
        public string NewPassword { get; set; }

        //[Required]
        [Display(Name="请再输入一次密码:")]
        [Compare("NewPassword", ErrorMessage = "两次输入的密码不一致。")]
        public string ConfirmNewPassword { get; set; }
    }
}