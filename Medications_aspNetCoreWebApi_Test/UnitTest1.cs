using Medications_aspNetCoreWebAPI.Controllers;
using Medications_aspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Medications_aspNetCoreWebApi_Test
{
    public class UnitTest1
    {
        private CHDBContext CreateContext(string databaseName)
        {
            var context = new CHDBContext(
                new DbContextOptionsBuilder<CHDBContext>().UseInMemoryDatabase(databaseName: databaseName).Options);
            context.Medications.AddRange(
                new Medication { MedicationId=1, MedicationDescription="Pain Reliever", MedicationCost=1.0M },
                new Medication { MedicationId=2, MedicationDescription="Analgesic", MedicationCost=1.25M },
                new Medication { MedicationId=3, MedicationDescription="Pain Killer", MedicationCost=1.5M }
            );
            context.SaveChanges();
            return context;
        }
        [Fact]
        public async Task Get_NoInput_ReturnsMedications()
        {
            //Arrange
            var medicationsController = new MedicationsController(CreateContext("Get"));
            //Act
            var actionResult = await medicationsController.GetMedications();
            //Assert
            Assert.IsType<ActionResult<IEnumerable<Medication>>>(actionResult);
            var medications = actionResult.Value as List<Medication>;
            Assert.Equal(3, medications.Count);
            Assert.Equal(1, medications[0].MedicationId);
            Assert.Equal("Analgesic", medications[1].MedicationDescription);
            Assert.Equal(1.5M, medications[2].MedicationCost);
        }
    }
}
