using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using HealthAssistant;

namespace HealthAssistant.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public User()
        {

        }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        public User(string Email, string Password, String DateOfBirth, int Weight, int Height)
        {
            this.Email = Email;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.Weight = Weight;
            this.Height = Height;
        }

        public bool IsLoginLegit()
        {            
            foreach (var member in GLOBALS.UserList)
            {
                if (this.Email == member.Email && this.Password == member.Password)
                    return true;
            }

            if (this.Email == "admin" && this.Password == "admin")
                return true;
            else
                return false;
        }

        public bool IsRegisterLegit()
        {
            if (CheckMail(this.Email) && !string.IsNullOrEmpty(this.Password) && !string.IsNullOrEmpty(this.DateOfBirth) && (0 < this.Weight) && (0 < this.Height))
            {
                GLOBALS.UserList.Add(this);
                return true;
            }
            else
                return false;
        }

        public bool CheckMail(string email)
        {
            var emailpattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, emailpattern);
        }
    }
}
