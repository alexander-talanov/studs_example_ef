using System;
using System.Collections.Generic;
using System.Linq;
using todo_list.Dto;

namespace todo_list
{
    public class ToDoRepository
    {
        // публичные функции репозитория
        public ToDoDto[] GetAll() {
            return Database
                .ConvertAll(x => new ToDoDto { Id = x.Id, Name = x.Name, Done = x.Done })
                .ToArray();
        }

        public int Add(ToDoDto toDoDto)
        {
            int id = GetId();
            Database.Add(new ToDo(id, toDoDto.Name, toDoDto.Done));
            return id;
        }

        public void Update(int id, ToDoDto toDoDto)
        {
            ToDo todo = Database.Find(x => x.Id == id);
            if (todo == null) return;
            todo.Name = toDoDto.Name;
            todo.Done = toDoDto.Done;
        }


        // скрытая реализация внутренних сущностей БД
        // сущность БД
        private class ToDo
        {
            public ToDo(int id, string name, bool done)
            {
                Id = id;
                Name = name;
                Done = done;
                CreationDate = DateTime.Now;
            }

            public int Id { get; }
            public string Name { get; set; }
            public bool Done { get; set; }
            public DateTime CreationDate { get; }
        }
        // эмуляция БД
        private static List<ToDo> Database = new List<ToDo>();
        // эмуляция генерации следующего Id БД
        private int GetId()
        {
            int nextId = 1;
            if ( Database.Count > 0 )
            {
                nextId = Database.Max(x => x.Id) + 1;
            }
            return nextId;
        }
    }
}
