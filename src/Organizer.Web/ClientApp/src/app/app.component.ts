import { Component } from '@angular/core';
import { ToDoService } from './todo.service';
import { ToDo } from './todo';

@Component({
    selector: 'app',
    templateUrl: './app.component.html'
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
    changeDescrition(event: Event,todo: ToDo) {
        //todo.description = (event.target as HTMLInputElement).value;

        let inputCtrl = (event.target as HTMLInputElement);
        //let updatedToDo = new ToDo();

        //updatedToDo.id = todo.id;
        //updatedToDo.description = inputCtrl.value;
        //updatedToDo.isDone = todo.isDone;
        
        //this.toDoService.updateToDo(updatedToDo).subscribe((result) => {
        //    if (result.isSuccess) {
        //        todo.description = updatedToDo.description;
        //    }
        //    else {
        //        console.log(todo.description);
        //        inputCtrl.value = todo.description;
        //    }
        //});

        todo.description = inputCtrl.value;
        this.toDoService.updateToDo(todo).subscribe();
    }
}