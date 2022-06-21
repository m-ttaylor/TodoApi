using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.InMemory.
namespace TodoApi.Models
{

    public class TodoItem
    {
        public long Id { get; set; }

        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string[]? Steps { get; set; }
        public string? Secret { get; set; }
    }
}