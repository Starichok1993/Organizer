﻿import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';;
import { TodoComponent } from './todo/todo.component'
;
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, NgbModule],
    declarations: [AppComponent, TodoComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }