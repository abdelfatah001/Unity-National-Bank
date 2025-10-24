using PL_WinForm.User_Controls.Detailed_Records_Screens.Add_Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PL_WinForm.User_Controls.Detailed_Records_Screens.Person
{
    public interface INameValidation { bool NameValidation(string FName, string LName); };

    public interface IPhoneValidation { bool PhoneNumValidation(string Phone); void InvalidName(); };

    public interface IEmailValidation { bool EmailValidation(string email); void InvalidEmail(); };

    public interface ICapitalization { string CaptializeFirstChar(string str); void InvalidPhone(); };


    public interface IPersonValidation  : INameValidation, IPhoneValidation, IEmailValidation, ICapitalization { }

    public class clsPersonDataValidation : IPersonValidation
    {

        public clsPersonDataValidation() { }

        public bool NameValidation(string FName, string LName)
        {
            return ( FName.All(char.IsLetter) && FName.Length > 3 && LName.All(char.IsLetter) && LName.Length > 3);
        }

        public bool PhoneNumValidation (string Phone)
        {
            return (Regex.IsMatch(Phone, @"^01[0125][0-9]{8}$"));
        }
        
        public bool EmailValidation(string email)
        {
            return (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.com$"));
        }

        public string CaptializeFirstChar(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public void InvalidName()
        {
            MessageBox.Show("Operation failed : Name is wrong input");
        }

        public void InvalidEmail()
        {
            MessageBox.Show("Operation failed : Email is wrong input");
        }
        public void InvalidPhone()
        {
            MessageBox.Show("Operation failed : Phone is wrong input");
        }


    }
}
