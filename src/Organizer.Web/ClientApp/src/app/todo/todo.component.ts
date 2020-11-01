import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ToDo } from './../todo';

@Component({
  selector: 'todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss']
})
export class TodoComponent {
  @Input() todo: ToDo;
  
  @Output() statusChanged = new EventEmitter<ToDo>();
  @Output() removed = new EventEmitter<ToDo>();
  @Output() updated = new EventEmitter<ToDo>();

  disabled = true;

  changeStatus(){
    this.todo.isDone = !this.todo.isDone;
    this.statusChanged.emit(this.todo);
  }

  remove(){
    this.removed.emit(this.todo);
  }

  update(){
    this.disabled = true;
    this.updated.emit(this.todo);    
  }

}
