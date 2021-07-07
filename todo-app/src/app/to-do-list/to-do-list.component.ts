import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

class ToDoItem {
  id: number;
  name: string;
  done: boolean;
  constructor(name: string) {
    this.name = name;
    this.done = false;
  }
}

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.css']
})
export class ToDoListComponent implements OnInit {

  newToDo = '';
  todos: ToDoItem[] = [];

  private _http: HttpClient;

  constructor( http: HttpClient ) {
    this._http = http;
  }

  async ngOnInit() {
    this.todos = await this._http.get<ToDoItem[]>('/api/todo').toPromise();
  }

  async addTodoHanler() {
    let newToDo: ToDoItem = new ToDoItem(this.newToDo);
    let newToDoId: number = await this._http.post<number>("/api/todo", newToDo).toPromise();
    newToDo.id = newToDoId;
    this.todos.push( newToDo );
    this.newToDo = '';
  }

  async updateTodoHandler( todo: ToDoItem ) {
    await this._http.put(`/api/todo/${todo.id}`, todo).toPromise();
  }

}
