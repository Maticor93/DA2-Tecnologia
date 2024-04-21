
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using System.Net.Http;
using System;
using Vidly.WebApi.Filters;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public class AuthenticationFilterTests
    {
        private Mock<HttpContext> _httpContextMock;
        private AuthorizationFilterContext _context;
        private AuthenticationFilterAttribute _attribute;

        [TestInitialize]
        public void Initialize()
        {
            _httpContextMock = new Mock<HttpContext>(MockBehavior.Strict);

            _context = new AuthorizationFilterContext(
                new ActionContext(
                    _httpContextMock.Object,
                    new Microsoft.AspNetCore.Routing.RouteData(),
                    new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            ),
                new List<IFilterMetadata>()
            );
            _attribute = new AuthenticationFilterAttribute();
        }

        #region Error
        [TestMethod]
        public void OnAuthorization_WhenEmptyHeaders_ShouldRerturnUnauthenticatedResponse()
        {
            _httpContextMock.Setup(h => h.Request.Headers).Returns(new HeaderDictionary());

            _attribute.OnAuthorization(_context);

            var response = _context.Result;

            response.Should().NotBeNull();
            var concreteResponse = response as ObjectResult;
            concreteResponse.Should().NotBeNull();
            concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }


        [TestMethod]
        public void OnAuthorization_WhenAuthorizationIsEmpty_ShouldRerturnUnauthenticatedResponse()
        {
            _httpContextMock.Setup(h => h.Request.Headers).Returns(new HeaderDictionary(new Dictionary<string, StringValues>
            {
                { "Authorization", string.Empty }
            }));

            _attribute.OnAuthorization(_context);

            var response = _context.Result;

            response.Should().NotBeNull();
            var concreteResponse = response as ObjectResult;
            concreteResponse.Should().NotBeNull();
            concreteResponse.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
            GetInnerCode(concreteResponse.Value).Should().Be("Unauthenticated");
            GetMessage(concreteResponse.Value).Should().Be("You are not authenticated");
        }
        #endregion

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