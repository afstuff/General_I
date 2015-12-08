using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

//using ABSGeneral.Data;
using ABSGeneral.Model;


namespace ABSGeneral.Repository
{
    public class UserAccount
    {
        //static readonly AbsDbContext DbContext = new AbsDbContext();

        public static string EncryptNew(string icText)
        {
            int icLen;
            string icNewText;
            string icChar;
            long i;
            icChar = "";
            icNewText = "";
            icLen = icText.Length;
            for (i = 1; (i <= icLen); i++)
            {
                icChar = icText.Substring((int)(i - 1), 1);
                switch (Strings.Asc(icChar))
                {
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90:
                        icChar = ((char)((Strings.Asc(icChar) + 127))).ToString();
                        break;
                    case 97:
                    case 98:
                    case 99:
                    case 100:
                    case 101:
                    case 102:
                    case 103:
                    case 104:
                    case 105:
                    case 106:
                    case 107:
                    case 108:
                    case 109:
                    case 110:
                    case 111:
                    case 112:
                    case 113:
                    case 114:
                    case 115:
                    case 116:
                    case 117:
                    case 118:
                    case 119:
                    case 120:
                    case 121:
                    case 122:
                        icChar = ((char)((Strings.Asc(icChar) + 121))).ToString();
                        break;
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                    case 56:
                    case 57:
                        icChar = ((char)((Strings.Asc(icChar) + 196))).ToString();
                        break;
                    case 32:
                        icChar = ' '.ToString();
                        break;
                }
                icNewText = (icNewText + icChar);
            }

            return icNewText;
        }

        public static string GetUserIdName(string userId)
        {
            using (var dbContext = new AbsDbContext())
            {
                ABSPASSTAB absuser = dbContext.ABSPASSTABs.FirstOrDefault(u => u.PWD_ID == userId);
                if (absuser != null)
                {
                    return absuser.PWD_USER_NAME;
                }
                return "Invalid CODE";
            }

        }

        public static ABSPASSTAB GetUserIdLogin(string userId, string userPwd)
        {
            using (var dbContext = new AbsDbContext())
            {
                var newPwd = EncryptNew(userPwd);
                ABSPASSTAB absuser =
                    dbContext.ABSPASSTABs.FirstOrDefault(u => u.PWD_ID == userId && u.PWD_CODE == newPwd);
                return absuser;
            }
        }

    }
}
