
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
    public class AuthenticationFilterTests
    {
        private Mock<HttpContext> _httpContextMock;
        private AuthorizationFilterContext _context;
        private AuthenticationFilterAttribute _attribute;

        public AuthenticationFilterTests()
        {
            _attribute = new AuthenticationFilterAttribute();
        }

        [TestInitialize]
        public void Initialize()
        {
            _httpContextMock = new Mock<HttpContext>(MockBehavior.Strict);

            _context = new AuthorizationFilterContext(
                new ActionContext(
                    _httpContextMock.Object,
                    new RouteData(),
                    new ActionDescriptor()
            ),
                new List<IFilterMetadata>()
            );
        }

        #region Error
        [TestMethod]
        public void OnAuthorization_WhenEmptyHeaders_ShouldRerturnUnauthenticatedResponse()
        {
            _httpContextMock.Setup(h => h.Request.Headers).Returns(new HeaderDictionary());

            _attribute.OnAuthorization(_context);

            var response = _context.Result;

            _httpContextMock.VerifyAll();
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
            
            _httpContextMock.VerifyAll();
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