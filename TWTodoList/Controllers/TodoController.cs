using Microsoft.AspNetCore.Mvc;
using TWTodoList.Context;
using TWTodoList.ViewModels;
using TWTodoList.Models;


namespace TWTodoList.Controllers;

public class TodoController : Controller
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var todos = _context.Todos.OrderBy(x => x.Date).ToList();
        var viewModel = new ListTodoViewModel { Todos = todos};
        
        return View(viewModel);
    }

    // Para acessar essa rota = Todo/Delete/Id 
    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo == null)
        {
            // Id não encontrado, exibir um erro
            return NotFound();
        }
        // Remover do banco o ID
        _context.Remove(todo);
        // Salvar a alteração
        _context.SaveChanges();
        //Redirecionar para Index
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Cadastrar Tarefa";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(FormTodoViewModel data)
    {
        var todo = new Todo(data.Title, data.Date);
        _context.Add(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo == null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Editar Tarefa";
        var viewModel = new FormTodoViewModel { Title = todo.Title, Date = todo.Date };
        return View("Form", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, FormTodoViewModel data)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.Title = data.Title;
        todo.Date = data.Date;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    // Para acessar essa rota = Todo/ToComplete/Id 
    public IActionResult ToComplete(int id)
    {
        var todo = _context.Todos.Find(id);
        if( todo == null)
        {
            return NotFound();
        }
        todo.IsCompleted = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
