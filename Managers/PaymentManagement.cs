using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;
using System.IO;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>

    public class PaymentManagement
    {
        PatientTestRepository test = new PatientTestRepository();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="res"></param>
        /// <param name="payment"></param>
        /// <param name="discount"></param>
        /// <param name="dis"></param>
        /// <returns></returns>
        /// 
        public object CreateSlip(TestResultDto res,decimal payment,bool discount,double dis)
        {
            var Test = test.GetTest(res.VisitID);
            Decimal price = Test.Price;
            decimal Discount = (Decimal)dis;

            if (payment>price)
            {
                if (discount.Equals(true))
                {

                    decimal FinalAmount = price - (price * Discount);
                    decimal balance = payment - FinalAmount;
                    this.PirntSlip(res, price, payment,Discount,balance,FinalAmount);
                }
                else
                {
                    decimal FinalAmount = price;
                    decimal balance = payment - FinalAmount;
                    this.PirntSlip(res,price, payment, 0, balance, FinalAmount);
                }
            }

            if (payment == price)
            {
                if (discount.Equals(true))
                {
                    decimal FinalAmount = price - (price * Discount);
                    decimal balance = payment - FinalAmount;
                    this.PirntSlip(res,price, payment, Discount, balance, FinalAmount);
                }
                else
                {
                    decimal FinalAmount = price;
                    decimal balance = payment - FinalAmount;
                    this.PirntSlip(res,price, payment, 0, balance, FinalAmount);
                }
            }

            else if (payment<price)
            {
                throw new InvalidOperationException("Invalid Payment amount insert ! ");
            }

            return null;
        }
 /// <summary>
 /// /
 /// </summary>
 /// <param name="res"></param>
 /// <param name="price"></param>
 /// <param name="payment"></param>
 /// <param name="discount"></param>
 /// <param name="balance"></param>
 /// <param name="FinalAmount"></param>
 /// <returns></returns>
 /// 
        public TestResultDto PirntSlip(TestResultDto res,Decimal price,decimal payment,decimal discount,decimal balance,decimal FinalAmount)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

            string fileName = "" + path + "\\paymentSlip.docx";

            var doc = DocX.Create(fileName);

            decimal dis = price * discount;

            doc.InsertParagraph(" _________________________________________________________________________");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("        LAB REPORT MANAGEMENT SYSTEM  | FINAL PAYEMENT DETAIL             ");
            doc.InsertParagraph(" _________________________________________________________________________");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("    Visit ID         : " + res.VisitID + "                                ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("    Test Price       Rs : " + price + "   Payment  Rs : " + payment + "   ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("    Discount         Rs : " + dis + "                                     ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph(" _________________________________________________________________________");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("    Final Amount  Rs : " + FinalAmount + "                                ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("    Balance Rs     Rs : " + balance + "                                   ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph(" _________________________________________________________________________");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("                                                                          ");
            doc.InsertParagraph("                                                                          ");

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
    }

   
}
