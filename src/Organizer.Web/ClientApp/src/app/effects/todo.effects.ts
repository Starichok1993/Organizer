import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { EMPTY } from 'rxjs';
import { map, mergeMap, catchError } from 'rxjs/operators';

import { ToDoService } from "../todo.service";
import * as todo from "../actions/todo.actions";


@Injectable()
export class TodoEffects {
    load$ = createEffect(() => this.actions$.pipe(
        ofType(todo.loadTodos),
        mergeMap(() => this.todoService.getToDos()
                .pipe(
                    map(result => todo.todosLoaded({ todos: result.data })),
                    catchError(() => EMPTY)))
        )
    );

    
    constructor(private actions$: Actions, private todoService: ToDoService) { }
}