import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { TodoComponent } from './todo/todo.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import * as fromRoot from './reducers/index';
import { TodoEffects } from './effects/todo.effects';

@NgModule({
    imports: [
        BrowserModule, 
        FormsModule, 
        HttpClientModule, 
        NgbModule,
        StoreModule.forRoot(fromRoot.reducers),
        StoreDevtoolsModule.instrument({ name: 'NgRx Book Store App' }),
        EffectsModule.forRoot([TodoEffects]),
    ],
    declarations: [AppComponent, TodoComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }