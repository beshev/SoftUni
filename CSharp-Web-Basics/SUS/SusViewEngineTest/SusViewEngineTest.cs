using SUS.MvcFramework.ViewEngine;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SusViewEngineTest
{
    public class SusViewEngineTest
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel()
            {
                DateOfBirth = new DateTime(2019, 6, 10),
                Name = "Dogo Argentino",
                Price = 12345.67M
            };

            var viewEngine = new SusViewEngine();

            var view = File.ReadAllText($"ViewTests/{fileName}.html");

            var actual = viewEngine.GetHtml(view, viewModel);
            var expected = File.ReadAllText($"ViewTests/{fileName}.Result.html");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestTemplateViewModel()
        {
            IViewEngine viewEngine = new SusViewEngine();
            var actual = viewEngine.GetHtml(@"@foreach(var num in Model)
{
<span>@num</span>
}", new List<int> { 1, 2, 3 });

            var expected = @"<span>1</span>
<span>2</span>
<span>3</span>
";

            Assert.Equal(expected,actual);
        }
    }

}
