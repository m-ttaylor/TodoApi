using FluentAssertions;
using TodoApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Text;

namespace BetterTodoApiTest;

public class DieControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    readonly HttpClient _client;

    public DieControllerTests(WebApplicationFactory<Program> application)
    {
        _client = application.CreateClient();
    }

    [Fact]
    public async Task GET_retrieves_weather_forecast()
    {
        var response = await _client.GetAsync("/api/die");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GET_retrieves_diealways3()
    {
        var response = await _client.GetAsync("/api/diealways3");

        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        responseString.Should().Be("3");
    }

    [Fact]
    public async Task POST_creates_todo_item()
    {
        var data = new TodoApi.Models.TodoItem();
        data.Name = "test";
        data.IsComplete = false;
        var json = JsonSerializer.Serialize(data);

        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


        var response = await _client.PostAsync("/api/todoitems", byteContent);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

    }

    [Fact]
    public async Task POST_creates_todo_item_with_steps()
    {
        var data = new TodoApi.Models.TodoItem();
        data.Name = "take out the trash";
        data.IsComplete = false;
        data.Steps = new List<string> { "remove bag from bin", "tie bag", "replace bag", "throw out old bag" };
        var json = JsonSerializer.Serialize(data);

        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


        var response = await _client.PostAsync("/api/todoitems", byteContent);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

    }
}