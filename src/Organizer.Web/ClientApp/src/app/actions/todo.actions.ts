import { createAction, props } from '@ngrx/store';
import { ToDo } from './../todo';

export const loadTodos = createAction(
    '[Todos] Load Todos'
);

export const todosLoaded = createAction(
    '[Todos] Todos Loaded',
    props<{ todos: ToDo[] }>()
);
