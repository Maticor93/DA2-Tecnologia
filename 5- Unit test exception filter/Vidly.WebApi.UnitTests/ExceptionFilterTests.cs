
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using Vidly.WebApi.Filters;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public class ExceptionFilterTests
    {
        private ExceptionContext _context;
        private ExceptionFilter _attribute;

        public ExceptionFilterTests()
        {
            _attribute = new ExceptionFilter();
        }

        [TestInitialize]
        public void Initialize()
        {
            _context = new ExceptionContext(
                new ActionContext(
                    new Mock<HttpContext>().Object,
                    new RouteData(),
                    new ActionDescriptor()),
                new List<IFilterMetadata>());
        }

        [TestMethod]
        public void OnException_WhenExceptionIsNotRegistered_ShouldResponseInternalError()
        {
            _context.Exception = new Exception("Not registered");

            _attribute.OnException(_context);

            var response = _context.Result;

            response.Should().NotBeNull();
            var concreteResponse = response as ObjectResult;
            concreteResponse.Should().NotBeNull();
            concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            GetInnerCode(concreteResponse.Value).Should().Be("InternalError");
            GetMessage(concreteResponse.Value).Should().Be("There was an error when processing the request");
        }

        private string GetInnerCode(object value)
        {
            return value.GetType().GetProperty("InnerCode").GetValue(value).ToString();
        }

        private string GetMessage(object value)
        {
            return value.GetType().GetProperty("Message").GetValue(value).ToString();
        }
    }
}