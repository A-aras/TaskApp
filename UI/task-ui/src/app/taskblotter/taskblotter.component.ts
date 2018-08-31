import { Component, OnInit, AfterViewInit } from '@angular/core';
import { TaskModel } from 'src/app/model/taskModel';
import { Input } from '@angular/core';
import { TaskserviceService } from 'src/app/taskservice.service';
import { TaskqueryComponent } from 'src/app/taskquery/taskquery.component';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-taskblotter',
  templateUrl: './taskblotter.component.html',
  styleUrls: ['./taskblotter.component.css']
})
export class TaskblotterComponent implements OnInit, AfterViewInit {

  @Input()
  Tasks: TaskModel[];

  @ViewChild("taskQuery")
  private taskQuery: TaskqueryComponent;
  constructor(private service: TaskserviceService) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    this.taskQuery.SearchObservable.subscribe(x => {
       this.service.queryTasks(x).subscribe(x=>{
         this.Tasks=x;});
    });
  }


}
