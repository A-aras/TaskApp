import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TaskrowComponent } from './taskrow/taskrow.component';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskqueryComponent } from './taskquery/taskquery.component';
import { TaskblotterComponent } from './taskblotter/taskblotter.component';
import { TaskeditorComponent } from './taskeditor/taskeditor.component';
import { TaskdetailsComponent } from './taskdetails/taskdetails.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { TaskdashboardComponent } from './taskdashboard/taskdashboard.component';
import { AppRoutingModule } from 'src/app/route/app.route.module';

@NgModule({
  declarations: [
    AppComponent,
    TaskrowComponent,
    TaskListComponent,
    TaskqueryComponent,
    TaskblotterComponent,
    TaskeditorComponent,
    TaskdetailsComponent,
    TaskdashboardComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
