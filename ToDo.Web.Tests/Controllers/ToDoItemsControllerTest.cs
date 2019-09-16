using Microsoft.EntityFrameworkCore;
using System;
using ToDo.Web.Controllers;
using Xunit;

namespace ToDo.Web.Tests.Controllers
{
    public class ToDoItemsControllerTest
    {
        [Fact]
        public void Test1()
        {
            int i = 1;
            Assert.IsType<int>(i);
        }
    }
}
