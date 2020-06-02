using System.Collections.Generic;
using System.Linq;
using Lab2.Controllers;
using Lab2;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Testing
{
    public class EmployeesTests
    {
        [Fact]
        public void GetTest()
        {
            var options = new DbContextOptionsBuilder<PharmacyDBContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PharmacyDB; Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var context = new PharmacyDBContext(options);
            EmployeesController controller = new EmployeesController(context);

            var TestEmployees = new Employees
            {
                Id = 1,
                FullName = "Some Name",
                IdBranch = 1,
                Salary = System.Convert.ToDecimal(100.0000),
                IdBranchNavigation = { }
            };
            var result = controller.GetEmployees(TestEmployees.Id).Result.Value;

            Assert.Equal(TestEmployees.FullName, result.FullName);//Assert
            Assert.Equal(TestEmployees.Salary, result.Salary);//Assert
        }


        [Fact]
        public void PostTest()
        {
            var options = new DbContextOptionsBuilder<PharmacyDBContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PharmacyDB; Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var context = new PharmacyDBContext(options);
            EmployeesController controller = new EmployeesController(context);

            var TestEmployees = new Employees { FullName = "UnitTest1", Salary = System.Convert.ToDecimal(1111.22222), IdBranch = 1 };
            var CallBack = (Employees)((CreatedAtActionResult)controller.PostEmployees(TestEmployees).Result.Result).Value;

            TestEmployees.Id = CallBack.Id;

            Assert.Equal(TestEmployees, CallBack);//Assert
        }


        [Fact]
        public void PostAndGetTest()
        {
            var options = new DbContextOptionsBuilder<PharmacyDBContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PharmacyDB; Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var context = new PharmacyDBContext(options);
            EmployeesController controller = new EmployeesController(context);

            var TestEmployees = new Employees { FullName = "UnitTest2", Salary = System.Convert.ToDecimal(1111.22222), IdBranch = 1 };
            var CallBack = (Employees)((CreatedAtActionResult)controller.PostEmployees(TestEmployees).Result.Result).Value;

            var result = controller.GetEmployees(CallBack.Id).Result.Value;

            Assert.Equal(CallBack, result);//Assert
        }


        [Fact]
        public void PostAndDeleteTest()
        {
            var options = new DbContextOptionsBuilder<PharmacyDBContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PharmacyDB; Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var context = new PharmacyDBContext(options);
            EmployeesController controller = new EmployeesController(context);

            var TestEmployees = new Employees { FullName = "UnitTest3", Salary = System.Convert.ToDecimal(1111.22222), IdBranch = 1 };
            var CallBack = (Employees)((CreatedAtActionResult)controller.PostEmployees(TestEmployees).Result.Result).Value;

            var result = controller.DeleteEmployees(CallBack.Id).Result.Value;

            Assert.Equal(CallBack, result);//Assert
        }
    }
}