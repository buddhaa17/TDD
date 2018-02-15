using AdditionOfStrings.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdditionOfStrings.Tests
{
    public class AdditionStringUnitTest
    {
        [Fact(DisplayName ="String addition when input string is empty")]
        public void AddString_Empty_String()
        {
            var controller = new StringAdditionController();
            var response = controller.Add("");
            Assert.Equal(0,response);
        }

        [Theory(DisplayName = "String addition when string contains only one number")]
        [InlineData("",0)]
        [InlineData("5",5)]
        [InlineData("@",0)]
        public void AddString_Contains_Single_Element(string inputString, int outputValue)
        {
            var controller = new StringAdditionController();
            var response = controller.Add(inputString);
            Assert.Equal(outputValue,response);
        }

        [Fact(DisplayName = "String addition when string contains more than 1 number")]
        public void AddString_MoreThan1Number()
        {
            var controller = new StringAdditionController();
            var response = controller.Add("1,2");
            Assert.Equal(3, response);
        }

        [Fact(DisplayName = "Add with new line character in the string.")]
        public void AddString_String_Contains_Newline()
        {
            var controller = new StringAdditionController();
            var response = controller.Add("1\n2,3");
            Assert.Equal(6, response);
        }

    }
}
