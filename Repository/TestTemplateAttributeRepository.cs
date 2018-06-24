using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
namespace Max.MedicalLab.Data.Entity.Repository
{
    public class TestTemplateAttributeRepository : MedLabRepository<TestTemplateAttribute>
    {
        public TestTemplateAttribute GetAttribute(string attrib)
        {
            var attribute = base.context.TestTemplateAttributes.AsNoTracking().FirstOrDefault(p => p.Attribute.Equals(attrib));
            return attribute;
        }
    }
}
