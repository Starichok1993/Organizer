import { Component } from '@angular/core';
import { ToDoService } from './todo.service';
import { ToDo } from './todo';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    name = '';
    todos: ToDo[];

    constructor(private toDoService: ToDoService) {
        toDoService.getToDos().subscribe(r => {
            this.todos = r.data;
        })
    }

    changeStatus(todo: ToDo) {
        todo.isDone = !todo.isDone;
        this.toDoService.updateToDo(todo).subscribe();
    }

    remove(todo: ToDo) {
        this.toDoService.deleteToDo(todo.id).subscribe(() => {
            const index = this.todos.indexOf(todo);
            if (index > -1) {
                this.todos.splice(index, 1);
            }
        });          
    }
    changeDescrition(todo: ToDo) {
        this.toDoService.updateToDo(todo).subscribe();
    }
}