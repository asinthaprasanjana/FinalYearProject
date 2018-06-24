using Max.MedicalLab.Business.Core.Managers;
using Max.MedicalLab.Data.EntityManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BizLayer.Core.Managers
{
    [TestClass]
    public class TestTemplateManagerUnitTest
    {
        [TestMethod]
        public void AddTestTemplate()
        {
            TestTemplate newtemplate = new TestTemplate()
            {
                TemplateName = "Thyroid biopsy",
                Price = 1800                
            };

            TestTemplateManager temp = new TestTemplateManager();
            var AddTemplate = temp.AddNewTemplate(newtemplate);

        }

        [TestMethod]
        public void AddAttribute()
        {
            TestTemplateAttribute attrib = new TestTemplateAttribute();
            {
                attrib.TemplateID = 2;
                attrib.Attribute = "Thyroid biopsy_Attribute9";
                attrib.PrefferedLimit = "1% - 3%";
            };

            TestTemplateManager attribute = new TestTemplateManager();
            var AddNewAttribute = attribute.Addattribute(attrib);
        }

        [TestMethod]
        public void UpdateAttribute()
        {
            TestTemplateAttribute attrib = new TestTemplateAttribute();
            {             
                attrib.Attribute = "Thyroid biopsy_Attribute2";
                attrib.PrefferedLimit = "1% - 7%";
                attrib.ModifiedBy = "MLT";
                attrib.ModifiedDate = DateTime.Now;  
            };

            TestTemplateManager attribute = new TestTemplateManager();
            var AddNewAttribute = attribute.Updateattribute(attrib);
        }

        [TestMethod]
        public void DeleteAttribute()
        {
            TestTemplateAttribute attrib = new TestTemplateAttribute();
            {
                attrib.AttrID = 18;
                attrib.TemplateID = 2;
                attrib.Attribute = "Thyroid biopsy_Attribute8";
                attrib.PrefferedLimit = "1% - 3%";
            };

            TestTemplateManager attribute = new TestTemplateManager();
            var AddNewAttribute = attribute.Deleteattribute(attrib);
        }

    }
}
