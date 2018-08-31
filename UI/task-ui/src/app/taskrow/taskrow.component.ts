import { Component, OnInit } from '@angular/core';
import { TaskModel } from 'src/app/model/taskModel';
import { Input } from '@angular/core';
import { TaskserviceService } from 'src/app/taskservice.service';
import { ActivatedRoute,Router } from '@angular/router';
import { RouterPreloader } from '@angular/router/src/router_preloader';

@Component({
  selector: '[app-taskrow]',
  templateUrl: './taskrow.component.html',
  styleUrls: ['./taskrow.component.css'],
  
})
export class TaskrowComponent implements OnInit {

  @Input()
  RowData:TaskModel;

  constructor(private service:TaskserviceService,private router:Router) { }

  ngOnInit() {
  }

  OnEdit(){
    this.router.navigate(["/EditTask",this.RowData.TaskId]);
  }

}
