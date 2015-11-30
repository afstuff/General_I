using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

using Microsoft.VisualBasic;

//using ABSGeneral.Data;
using ABSGeneral.Model;

namespace ABSGeneral.Repository
{
    public class NiidModule
    {
        static readonly NiidDbContext DbContext = new NiidDbContext();

        public int NetworkStatus()
        {
            try
            {
                NIID_MotorDetails_Online md = DbContext.NIID_MotorDetails_Online.FirstOrDefault(m => m.NIID_NO == 1);
            }
            catch (NetworkInformationException v)
            {

                string d = v.Message;
                return 0;
            }
            catch (Exception y)
            {

                //string k = y.InnerException.Message;
                return 0;
            }
            return 1;
        }


        public IQueryable<NIID_MotorDetails_Online> GetVehicleDateailsAll()
        {
            //using (DbContext)
            //{
            IQueryable<NIID_MotorDetails_Online> motorDetails = DbContext.NIID_MotorDetails_Online.Where(n => n.NIID_Status != "X");
            return motorDetails;
            //}

        }

        public IQueryable<NIID_MotorDetails_Online> GetMotorDetailsOnlineByDate(DateTime? startDate, DateTime? endDate, int filter, string sValue)
        {
            IQueryable<NIID_MotorDetails_Online> md;
            if (filter == 0)
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from m in md
                                                             where (m.NIID_UploadDate >= startDate && m.NIID_UploadDate <= endDate)
                                                             select m;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if (filter == 1 && sValue != "*")
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from c in md
                                                             where (c.NIID_UploadDate >= startDate && c.NIID_UploadDate <= endDate)
                                                             && c.NIID_InsuredName.ToLower().Contains(sValue.ToLower())
                                                             select c;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if (filter == 2 && sValue != "*")
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from d in md
                                                             where (d.NIID_UploadDate >= startDate && d.NIID_UploadDate <= endDate)
                                                             && d.NIID_PolicyNo.ToLower().Contains(sValue.ToLower())
                                                             select d;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if (filter == 3 && sValue != "*")
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from e in md
                                                             where (e.NIID_UploadDate >= startDate && e.NIID_UploadDate <= endDate)
                                                             && e.NIID_RegistrationNo.ToLower().Contains(sValue.ToLower())
                                                             select e;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if (filter == 4)
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from e in DbContext.NIID_MotorDetails_Online
                                                             where (e.NIID_UploadDate >= startDate && e.NIID_UploadDate <= endDate)
                                                             && e.NIID_Status=="P" 
                                                             //&& e.NIID_RegistrationNo.ToLower().Contains(sValue.ToLower())
                                                             select e;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if (filter == 5)
            {
               // md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from e in DbContext.NIID_MotorDetails_Online
                                                             where (e.NIID_UploadDate >= startDate && e.NIID_UploadDate <= endDate)
                                                             && e.NIID_Status == "A" 
                                                             //&& e.NIID_Status == "X"
                                                             //&& e.NIID_RegistrationNo.ToLower().Contains(sValue.ToLower())
                                                             select e;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            if ((filter == 3 || filter == 2 || filter == 1) && sValue == "*")
            {
                md = GetVehicleDateailsAll();
                IQueryable<NIID_MotorDetails_Online> newMd = from e in md
                                                             where (e.NIID_UploadDate >= startDate && e.NIID_UploadDate <= endDate)
                                                             //&& e.NIID_RegistrationNo.ToLower().Contains(sValue.ToLower())
                                                             select e;
                if (newMd != null)
                {
                    return newMd;
                }
            }

            md = GetVehicleDateailsAll();
            return md;
        }

        public void Update(int polyNo)
        {
            NIID_MotorDetails_Online md = DbContext.NIID_MotorDetails_Online.FirstOrDefault(p => p.NIID_NO == polyNo);
            md.NIID_Status = "X";
            DbContext.SaveChanges();
        }

        public void Update1(int polyNo)
        {
            NIID_MotorDetails_Online md = DbContext.NIID_MotorDetails_Online.FirstOrDefault(p => p.NIID_NO == polyNo);
            md.NIID_Status = "P";
            DbContext.SaveChanges();
        }
    }
}
