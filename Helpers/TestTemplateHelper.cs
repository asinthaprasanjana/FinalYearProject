using Max.MedicalLab.Data.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.MedicalLab.Business.Core.Helpers
{
    class TestTemplateHelper
    {
        private readonly TestTemplateRepository TestTemplateRepo;

        public TestTemplateHelper()
        {
            TestTemplateRepo = new TestTemplateRepository();
        }
    }
}
