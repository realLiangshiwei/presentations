using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace TodoApp;

public class TodoAppService : TodoAppAppService, ITodoAppService
{
    private readonly IRepository<TodoItem, Guid> _todoRepository;

    public TodoAppService(IRepository<TodoItem, Guid> todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var todoItems= await _todoRepository.GetListAsync();

        return ObjectMapper.Map<List<TodoItem>, List<TodoItemDto>>(todoItems);
    }

    public async Task<TodoItemDto> CreateAsync(string text)
    {
        var todoItem = await _todoRepository.InsertAsync(new TodoItem { Text = text });

        return ObjectMapper.Map<TodoItem, TodoItemDto>(todoItem);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _todoRepository.DeleteAsync(id);
    }
}
