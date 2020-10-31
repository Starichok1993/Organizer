import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToDo } from './todo';
import { ServerResult } from './serverResult';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ToDoService {

    private url = "/api/todo";

    constructor(private http: HttpClient) {
    }

    getToDos(): Observable<ServerResult<ToDo[]>> {
        return this.http.get<ServerResult<ToDo[]>>(this.url);        
    }

    getToDo(id: number): Observable<ServerResult<ToDo>>{
        return this.http.get<ServerResult<ToDo>>(this.url + '/' + id);
    }

    createToDo(todo: ToDo): Observable<ServerResult<number>> {
        return this.http.post<ServerResult<number>>(this.url, todo);
    }
    updateToDo(todo: ToDo): Observable<ServerResult> {
        return this.http.put<ServerResult>(this.url, todo);
    }
    deleteToDo(id: number): Observable<ServerResult> {
        return this.http.delete<ServerResult>(this.url + '/' + id);
    }
}