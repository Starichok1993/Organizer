import { createSelector } from '@ngrx/store';
import * as fromTodos from './todo.reducers';


export interface State {
    todos: fromTodos.State;
}

export const reducers = {
    todos: fromTodos.reducer
}

export const selectTodosState = (state: State) => state.todos;

export const selectTodos = createSelector(selectTodosState, fromTodos.selectTodos);
export const selectActiveTodos = createSelector(selectTodosState, fromTodos.selectActiveTodos);

export const isLoading = createSelector(selectTodosState, fromTodos.isLoading);