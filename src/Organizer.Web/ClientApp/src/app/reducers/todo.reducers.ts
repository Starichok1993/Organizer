import { createEntityAdapter, EntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, createSelector, on } from '@ngrx/store';
import { ToDo } from '../todo';
import * as TodoActions from './../actions/todo.actions';

export interface State extends EntityState<ToDo> {
  loading: boolean;
}

export const adapter: EntityAdapter<ToDo> = createEntityAdapter<ToDo>({
    selectId: (todo: ToDo) => todo.id,
    sortComparer: false,
});


export const initialState: State = adapter.getInitialState({
  loading: false
});


export const reducer = createReducer(
    initialState, 
    on(
      TodoActions.loadTodos,
      (state) => ({...state, loading: true })
    ),   
    on(
      TodoActions.todosLoaded,        
      (state, { todos }) => adapter.setAll(todos, {...state, loading: false })
    )
);

// get the selectors
const {
    selectAll
  } = adapter.getSelectors();

  export const selectTodos = selectAll;
  export const selectActiveTodos = createSelector(selectTodos, (todos: ToDo[]) => todos.filter(t => !t.isDone));

  export const isLoading = (state: State) => state.loading;