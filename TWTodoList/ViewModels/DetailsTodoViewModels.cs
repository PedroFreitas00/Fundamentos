using TWTodoList.Models;

namespace TWTodoList.ViewModels;

public class DetailsTodoViewModels
{
    public Todo Todo { get; set; } = null!;
    public string PageTitle { get; set; } = string.Empty;
}
