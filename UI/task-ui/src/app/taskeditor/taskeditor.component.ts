import { Component, OnInit } from '@angular/core';
import { TaskConstants } from '../Const/taskConstants'
import { ParentTaskModel } from 'src/app/model/parentTaskModel';
import { TaskserviceService } from 'src/app/taskservice.service';
import { FormArray, Form, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { TaskModel } from 'src/app/model/taskModel';
import { Input } from '@angular/core';
import { DefaultValueValidator, DateMustbeGreaterThanValidation } from 'src/app/validators/dropdownDefaultValueValidator';
import { Router, Route, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { of } from 'rxjs';


@Component({
  selector: 'app-taskeditor',
  templateUrl: './taskeditor.component.html',
  styleUrls: ['./taskeditor.component.css']
})
export class TaskeditorComponent implements OnInit {

  myform: FormGroup;
  taskName: FormControl;
  priority: FormControl;
  parentTask: FormControl;
  dateFormGroup: FormGroup;
  startDate: FormControl;
  endDate: FormControl;

  @Input()
  model: TaskModel;

  readonly priorityMin = TaskConstants.prototype.priorityMin;
  readonly priorityMax = TaskConstants.prototype.priorityMax;

  ParentTasks: ParentTaskModel[];
  constructor(private service: TaskserviceService, private router: Router, private activeRoute: ActivatedRoute) {
    //     this.activeRoute.paramMap.pipe(switchMap((parms:ParamMap)=>{
    //       if(parms.has("id"))
    //       {
    // return new TaskModel();
    //       }
    //       return new TaskModel();
    //     })).subscribe(x=>{
    //       this.model=x;
    //     });
    this.model = new TaskModel();
    this.activeRoute.paramMap.pipe(switchMap((parms: ParamMap) => {
      console.log(parms);
      if (parms.has("id")) {
        let id = Number.parseInt(parms.get("id"));
        return this.service.getTaskById(id);
      }
      return of(new TaskModel());
    })).subscribe(x => {
      this.model = x

      this.taskName.setValue(x.TaskDescription);
      this.parentTask.setValue(x.ParentTaskId);
      this.priority.setValue(x.Priority);
      this.startDate.setValue(x.StartDate);
      this.endDate.setValue(x.EndDate);
      // this.taskName.setValue(x.TaskDescription);
      // this.taskName.setValue(x.TaskDescription);
      // this.taskName.setValue(x.TaskDescription);
    });

    service.getAllParentTask().subscribe
      (x => {
        this.ParentTasks = x;
      });

  }
  ngOnInit() {
    // if (this.model == null) {
    //   this.model = new TaskModel();
    // }

    this.taskName = new FormControl(this.model.TaskDescription, Validators.required);
    this.priority = new FormControl(this.model.Priority, Validators.required);
    this.parentTask = new FormControl(this.model.ParentTask, [DefaultValueValidator("")]);

    this.startDate = new FormControl(this.model.StartDate, Validators.required)
    this.endDate = new FormControl(this.model.EndDate, Validators.required)

    let dateValidator = DateMustbeGreaterThanValidation("startDate", "endDate");
    //this.dateFormGroup=new FormGroup({startDate:this.startDate,endDate:this.endDate},Validators.compose([DateMustbeGreaterThanValidation("startDate","endDate")]));
    this.dateFormGroup = new FormGroup({ startDate: this.startDate, endDate: this.endDate });
    this.dateFormGroup.setValidators(dateValidator);

    this.myform = new FormGroup({ taskName: this.taskName, priority: this.priority, parentTask: this.parentTask, dateGroup: this.dateFormGroup });


  }

  OnAddTask() {
    if (this.myform.valid) {
      this.model.TaskDescription = this.taskName.value;
      this.model.Priority = this.priority.value;
      this.model.ParentTask = this.parentTask.value;
      this.model.StartDate = this.startDate.value;
      this.model.EndDate = this.endDate.value;

      this.service.AddTaks(this.model).subscribe(x => {
        console.log("Task Saved...");
      });

      console.log("Form is Valid");

    }
  }
}
