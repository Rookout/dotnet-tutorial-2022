using System;
namespace dotnet_tutorial_2022.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool? Completed { get; set; }
        public int? Order { get; set; }

        public Todo()
        {

        }

        public Todo(string title, string url, string id)
        {
            Title = title;
            Id = id;
            Url = url;
        }

        public Todo(string title, string url, string id, bool completed, int order)
        {
            Title = title;
            Id = id;
            Url = url;
            Completed = completed;
            Order = order;
        }
    }
}

