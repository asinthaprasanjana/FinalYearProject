using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Max.MedicalLab.Data.EntityManager;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Data.Entity.Repository;
using AutoMapper;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTemplateManager: MedLabRepository<TestTemplateAttribute>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newtemplate"></param>
        /// <returns></returns>
        public TestTemplateDto AddNewTemplate(TestTemplate newtemplate)
        {
            TestTemplateRepository repo = new TestTemplateRepository();
            MapperConfig.ConfigAutoMapper();

            if (this.IsValidTest(newtemplate))
            {

                if (repo.GetTestTemplate(newtemplate.TemplateName)==null) 
                {
                    newtemplate.CreatedDate = DateTime.Now;
                    newtemplate.CreatedBy = "Test";
                    newtemplate.ModifiedBy = string.Empty;
                    newtemplate.ModifiedDate = null;

                    var savetemp = repo.Insert(Mapper.Map<TestTemplate>(newtemplate));

                    return Mapper.Map<TestTemplateDto>(savetemp);

                }
                else

                {
                    throw new InvalidOperationException("Template is not acceptable.Already saved template");
                }
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public TestTemplateAttributeDto Updateattribute(TestTemplateAttribute attrib)
        {
            TestTemplateAttributeRepository repo = new TestTemplateAttributeRepository();

            attrib.CreatedDate = repo.GetAttribute(attrib.Attribute).CreatedDate;

            attrib.AttrID = repo.GetAttribute(attrib.Attribute).AttrID;

            attrib.TemplateID = repo.GetAttribute(attrib.Attribute).TemplateID;

            attrib.CreatedBy = repo.GetAttribute(attrib.Attribute).CreatedBy;

            MapperConfig.ConfigAutoMapper();

            {
                repo.Update(Mapper.Map<TestTemplateAttribute>(attrib));
            }

            return null;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public TestTemplateAttributeDto Addattribute(TestTemplateAttribute attrib)
        {
            TestTemplateAttributeRepository repo = new TestTemplateAttributeRepository();
            MapperConfig.ConfigAutoMapper();

            if (this.IsValidAttribute(attrib))
            {

                if (repo.GetAttribute(attrib.Attribute) == null)
                {
                    attrib.CreatedDate = DateTime.Now;
                    attrib.CreatedBy = "MLT";
                    attrib.ModifiedBy = null;
                    attrib.ModifiedDate = null;

                    var saveattrib = repo.Insert(Mapper.Map<TestTemplateAttribute>(attrib));

                    return Mapper.Map<TestTemplateAttributeDto>(attrib);

                }
                else

                {
                    throw new InvalidOperationException("Template is not acceptable.Already saved template");
                }
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrib"></param>
        /// <returns></returns>
        public TestTemplateAttributeDto Deleteattribute(TestTemplateAttribute attrib)
        {
            TestTemplateAttribute Delattribute = context.TestTemplateAttributes.SingleOrDefault(item => item.AttrID == attrib.AttrID);

            context.TestTemplateAttributes.Remove(Delattribute);

            context.SaveChanges();

            return null;
        }

        private bool IsValidAttribute(TestTemplateAttribute attrib)
        {
            if (attrib == null)
            {
                throw new ArgumentNullException("Attribute does not exists");
            }

            if (attrib.TemplateID.ToString() == null)
            {
                throw new ArgumentNullException("Blank template");
            }

            if (attrib.PrefferedLimit == null)
            {
                throw new ArgumentNullException("Blank Limit");
            }

            if (attrib.Attribute == null)
            {
                throw new ArgumentNullException("Blank Attribute name");
            }
            return true;
        }

        private bool IsValidTest(TestTemplate template)
        {

            if (template == null)
            {
                throw new ArgumentNullException("Test does not exists");
            }

            if (string.IsNullOrEmpty(template.TemplateName))
            {
                throw new ArgumentNullException("Insert Name Field!");
            }

            if (template.Price.ToString()==null)
            {
                throw new ArgumentNullException("Insert Price field");
            }

            return true;
        }
    }
}
