import { Component, OnInit } from '@angular/core';
import { ToDoService } from './todo.service';
import { ToDo } from './todo';
import { Observable } from 'rxjs';
import * as fromRoot from './reducers/index';
import { Store } from '@ngrx/store';
import * as fromTodos from './actions/todo.actions';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit {
    name = '';

    todos$: Observable<ToDo[]>;
    loading$: Observable<boolean>;

    constructor(private store: Store<fromRoot.State>) {
        this.todos$ = this.store.select(fromRoot.selectActiveTodos);
        this.loading$ = this.store.select(fromRoot.isLoading);
    }

    ngOnInit() {
        this.store.dispatch(fromTodos.loadTodos());
    }

    changeStatus(todo: ToDo) {
        // this.toDoService.updateToDo(todo).subscribe();
    }

    remove(todo: ToDo) {
        // this.toDoService.deleteToDo(todo.id).subscribe(() => {
        //     const index = this.todos.indexOf(todo);
        //     if (index > -1) {
        //         this.todos.splice(index, 1);
        //     }
        // });          
    }

    changeDescription(todo: ToDo) {
        // this.toDoService.updateToDo(todo).subscribe();
    }

    addTodo(){
        // var todo = new ToDo();
        // this.toDoService.createToDo(todo).subscribe((result) => {
        //     todo.id = result.data;
        //     this.todos.push(todo);
        // })
    }
}