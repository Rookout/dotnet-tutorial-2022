using System;
namespace dotnet_tutorial_2022.ViewModels
{
    public class VTodo
    {
        public string Title { get; set; }
        public bool? Completed { get; set; }
        public int? Order { get; set; }

        public VTodo()
        {
        }

        public VTodo(string title)
        {
            Title = title;
        }

        public VTodo(string title, bool completed, int order)
        {
            Title = title;
            Completed = completed;
            Order = order;
        }
    }
}

