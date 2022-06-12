using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using TLM.Books.Application.Models;
using TLM.Books.Common.Error;
using TLM.Books.IntegrationTests.Configurations;
using Xunit;

namespace TLM.Books.IntegrationTests.Scenarios.Users;

[Collection(nameof(UserCollectionFixtureDefinition))]
public class UserTests
{
    private readonly UserApplicationFactory _factory;

    public UserTests(UserApplicationFactory factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async Task QueryUser_GetAllUsers_ShouldBeSuccess()
    {
        var client = _factory.CreateDefaultClient();
        
        var response = await client.GetAsync("/api/users");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var result = await response.GetContentAsync<MethodResult<IEnumerable<UserView>>>();
        Assert.NotNull(result);
        Assert.True(result.IsOK);
        Assert.NotNull(result.Result);
        Assert.NotEmpty(result.Result);
    }
}