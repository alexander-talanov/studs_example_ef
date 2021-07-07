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
        private IUnitOfWork _unitOfWork;

        public ToDoRepository( ToDoDbContext context, IUnitOfWork unitOfWork )
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public ToDoDto[] GetAll()
        {
            return _context.Set<ToDoEntity>().ToList()
                .ConvertAll( x => new ToDoDto { Id = x.Id, Name = x.Name, Done = x.Done } )
                .ToArray();
        }

        public int Add( ToDoDto toDoDto )
        {
            ToDoEntity newEntity = new ToDoEntity
            {
                Name = toDoDto.Name,
                Done = toDoDto.Done
            };
            _context.Set<ToDoEntity>().Add( newEntity );
            _unitOfWork.Commit();

            return newEntity.Id;
        }

        public void Update( int id, ToDoDto toDoDto )
        {
            ToDoEntity entity = _context.Set<ToDoEntity>().FirstOrDefault( item => item.Id == id );
            entity.Name = toDoDto.Name;
            entity.Done = toDoDto.Done;
            _unitOfWork.Commit();
        }
    }
}
