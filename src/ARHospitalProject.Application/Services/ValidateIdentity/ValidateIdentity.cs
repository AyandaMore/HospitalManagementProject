using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARHospitalProject.Services.AppServices.PersonApp
{
    public class ValidateIdentity
    {
        public static bool CheckIDNumber(string idNum)
        {
            bool lengthCheck;
            bool genderCheck;
            bool citizenCheck;

            if (idNum.Length < 13)
            {
                 lengthCheck = false;
            }
            else
            {
                lengthCheck = true;
            }
            
                string genderPart = idNum.Substring(6, 4);
                int genderNum = Convert.ToInt32(genderPart);
          
                if (genderNum > 0 && genderNum < 4999  )
                {
                genderCheck = true;
                }
                else if (genderNum > 4999 && genderNum < 9999)
                {
                genderCheck = true;
                }
                else
            {
                genderCheck = false;
            }

            string citizenshipPart = idNum.Substring(10, 1);
            int citizenShipNum = Convert.ToInt32(citizenshipPart);
            if (citizenShipNum != 0 || citizenShipNum != 1)
            {
                citizenCheck = false;
            }
            else
            {
                citizenCheck = true;
            }
            

            if (lengthCheck == true && genderCheck == true && citizenCheck == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CheckPassportNumber(string passportNum)
        {
            if (passportNum.Length < 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
