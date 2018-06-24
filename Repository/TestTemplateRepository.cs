using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
namespace Max.MedicalLab.Data.Entity.Repository
{
    public class TestTemplateRepository:MedLabRepository<TestTemplate>
    {
        public TestTemplate GetTestTemplate(string templatename)
        {
            var testTemplate = base.context.TestTemplates.FirstOrDefault(p => p.TemplateName.Equals(templatename));
            return testTemplate;
        }
    }
}
