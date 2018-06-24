using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using Max.MedicalLab.Data.EntityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using Novacode;
using Max.MedicalLab.Business.Core.Helper;
using System.IO;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public class ReportGenerateManagement : MedLabRepository<Patient>
    {
        PatientTestResultHelper resultSet = new PatientTestResultHelper();
        PatientVisitHelper VisitHelper = new PatientVisitHelper();
        PatientTestRepository test = new PatientTestRepository();
        PatientVisitRepository visit = new PatientVisitRepository();
        PatientRepository patient = new PatientRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="printreport"></param>
        /// <returns></returns>
        public TestResultDto PrintReport(TestResultDto printreport)
        {
            MapperConfig.ConfigAutoMapper();



            if (printreport != null)
            {
                int patientid = visit.GetVisit(printreport.VisitID).PatientID;
                var patient = base.context.Patients.AsNoTracking().FirstOrDefault(p => p.PatientId.Equals(patientid));

                String name = patient.Name;
                int age = patient.Age;
                string sex = patient.Gender;
                string address = patient.Address;
                string number = patient.ContactNo;

                DateTime arrivedate = visit.GetVisit(printreport.VisitID).ArriveDate;
                DateTime ExpDelDate = visit.GetVisit(printreport.VisitID).ExpectedDeliveryDate;

                int TesTID = test.GetTest(printreport.VisitID).TemplateID;
                var testTemplate = base.context.TestTemplates.FirstOrDefault(p => p.TestTemplateId.Equals(TesTID));


                string templatename = testTemplate.TemplateName;
                int temID = testTemplate.TestTemplateId;
                decimal price = testTemplate.Price;

               
                IList<TestResultDto> results = resultSet.GetTestResults(printreport.VisitID);
                IList<TestTemplateAttributeDto> Attribs = VisitHelper.GetTestTemplateAttributes(temID);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string fileName = "" + path + "\\Report.docx";

                var doc = DocX.Create(fileName);

                doc.InsertParagraph(" __________________________________________________________________________________________________                                  ");
                doc.InsertParagraph("");
                doc.InsertParagraph("                      MEDICAL LAB REPORT MANAGEMENT SYSTEM  |  FINAL TEST REPORT ");
                doc.InsertParagraph("");
                doc.InsertParagraph(" __________________________________________________________________________________________________                                  ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("     Patient Name : " + name + "                                    Gender : " + sex + "                                             ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("     Patient Age : " + age + "                                                        Address:" + address + "   Payment : RS: "+price+"");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("     Contact Number : " + number + "                                    Test : " + templatename + "                                  ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph("");

                doc.InsertParagraph("     Arrived Date: " + arrivedate + "                      Deliver Date:" + ExpDelDate + "                                           ");
                doc.InsertParagraph("                                                                                                                                     ");
                doc.InsertParagraph(" __________________________________________________________________________________________________                                  ");

                doc.InsertParagraph("");
                doc.InsertParagraph("     Patients Results ");
                doc.InsertParagraph("");
                doc.InsertParagraph("");

                int seq = 1;
                foreach (var x in results)
                {
                    doc.InsertParagraph("     " + seq + "           Value: " + x.Value + "              Status : " + x.Status + "");
                    doc.InsertParagraph("");
                    seq++;

                    if (seq > Attribs.Count)
                    {
                        break;
                    }
                }

                doc.InsertParagraph("");
                doc.InsertParagraph("");
                doc.InsertParagraph("    Reffer below Information. ");
                doc.InsertParagraph("");
                doc.InsertParagraph("");

                int NextSeq = 1;
                foreach (var x in Attribs)
                {
                    doc.InsertParagraph("     " + NextSeq + " . " + x.Attribute + " --> " + x.PrefferedLimit + "");
                    doc.InsertParagraph("");
                    doc.InsertParagraph("");
                    NextSeq++;

                }

                doc.Save();

                /*Open as html format*/
                SautinSoft.RtfToHtml z = new SautinSoft.RtfToHtml();
                string docxFile = Path.GetFullPath(fileName);
                string htmlFile = Path.ChangeExtension(docxFile, ".html");

                z.OpenDocx(docxFile);
                z.ToHtml(htmlFile);
                System.Diagnostics.Process.Start(htmlFile);

                return null;

            }

            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Patient"></param>
        /// <returns></returns>
        /// 
        public Patient GetTest(PatientDto Patient)

        {
            if (Patient.ContactNo.Length<=10) {

                if (patient.GetPatient(Patient.ContactNo) != null)
                {

                    int PatientID = patient.GetPatient(Patient.ContactNo).PatientId;

                    if (VisitHelper.GetVisitByPatientID(PatientID) == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Visit Not Found!");

                    }
                    else
                    {

                        int visitid = VisitHelper.GetVisitByPatientID(PatientID).PatientVisitId;

                        System.Diagnostics.Debug.WriteLine("Visit Found!");

                        if (test.GetTest(visitid) == null)
                        {
                            System.Diagnostics.Debug.WriteLine("Test Not Found!");

                            PatientTest Test = test.GetTest(visitid);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Test Found!");
                            PatientTest Test = test.GetTest(visitid);

                        }


                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Patient Not Found!");
                } 

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Invalid Contact Number");
            }

            return null;
        }
    }
}
