using System;
using System.Collections.Generic;
using System.Linq;
using todo_list.DbInfrastructure;
using todo_list.Dto;
using todo_list.Entities;

namespace todo_list
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoDbContext _context;

        public ToDoRepository( ToDoDbContext context )
        {
            _context = context;
        }

        public ToDoDto[] GetAll()
        {
            return _context.Set<ToDoEntity>().ToList()
                .ConvertAll( x => new ToDoDto { Id = x.Id, Name = x.Name, Done = x.Done } )
                .ToArray();
        }

        public int Add( ToDoDto toDoDto )
        {
            throw new NotImplementedException();
        }

        public void Update( int id, ToDoDto toDoDto )
        {
            throw new NotImplementedException();
        }
    }
}
