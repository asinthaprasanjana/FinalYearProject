using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.Entity.Repository;
namespace Max.MedicalLab.Business.Core.Helpers
{
    class DoctorHelper
    {
        private readonly DoctorRepository DocRepo;

        public DoctorHelper()
        {
            DocRepo = new DoctorRepository();
        }
    }
}
