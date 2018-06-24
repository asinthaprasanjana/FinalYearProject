using Max.MedicalLab.Data.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Business.Core.Helpers
{
    class TestStatusHelper
    {
        private readonly TestStatusRepository TestStatusRepo;

        public TestStatusHelper()
        {
            TestStatusRepo = new TestStatusRepository();
        }
    }
}
