using todo_list.Dto;

namespace todo_list
{
    public interface IToDoRepository
    {
        ToDoDto[] GetAll();
        int Add( ToDoDto toDoDto );
        void Update( int id, ToDoDto toDoDto );
    }
}
