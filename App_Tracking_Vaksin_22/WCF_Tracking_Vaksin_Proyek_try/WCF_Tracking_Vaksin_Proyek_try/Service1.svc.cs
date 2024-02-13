using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Tracking_Vaksin_Proyek_try
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly proyek_tryEntities _context;

        public Service1()
        {
            _context = new proyek_tryEntities();
        }

        public List<ReportInnVaksin> GetReportVaksin(string id)
        {
            return _context.ReportInnVaksins.Where(u=> u.id_rumah_sakit == id).ToList();
        }
        public List<ReportUseVaksin> GetRecordVaksin(string id)
        {
            return _context.ReportUseVaksins.Where(u => u.id_rumah_sakit == id).ToList();
        }

        public List<Vaksin> GetAllVaksins()
        {
            return _context.Vaksins.ToList();
        }
        public List<Penduduk> GetAllPenduduk()
        {
            return _context.Penduduks.ToList();
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
