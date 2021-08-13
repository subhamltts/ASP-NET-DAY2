using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectX_BL;
using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL.Tests
{
    [TestClass()]
    public class ProjectXBLTests
    {
        [TestMethod()]
        public void ParticipantInputValuesTest()
        {
            ParticipantDTO obj = new ParticipantDTO{ ParticipantID = 99004941, ParticipantName = "Akshat Vyas", ParticipantEmailID = "akshat.vyas@gmail.com" };
            ParticipantsBL xblObj = new ParticipantsBL();
            var expe = obj.ParticipantName;
            var actual = xblObj.ParticipantInputValues(99004941, "Akshat Vyas", "akshat.vyas@gmail.com").ParticipantName;
            Assert.AreEqual(expe, actual);
        }
    }
}