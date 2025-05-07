using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;



namespace BusinessLogicLayer.BLL.Tests
{
    [TestClass()]
    public class SpringerBLLTests
    {
        [TestMethod()]
        public void getSpringerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllSpringereTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void CreateSpringerTest()
        {
            string navn = "Frederik Madsen";
            DateTime? foedselsdato = new DateTime(2012, 07, 08);
            List<string> hold = new List<string>();
            string tirsdag = "Tirsdag hold 1";
            hold.Add(tirsdag);


            string kontaktNavn = "Anders Andersen";
            string kontaktTelefon = "12345678";
            string kontaktEmail = "anders@example.com";

            // Assert.Equals("Anders Andersen", kontaktNavn);

            var result = SpringerBLL.CreateSpringer(navn, foedselsdato, kontaktNavn, kontaktTelefon, kontaktEmail, hold);

           Assert.AreEqual("Frederik Madsen", result.Navn);

        }
    }
}