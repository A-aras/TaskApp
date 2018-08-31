import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';
import { filter, map } from 'rxjs/operators';
import { Output } from '@angular/core';
import { TaskQueryModel } from 'src/app/model/taskQueryModel';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { DateMustbeGreaterThanValidation, NumberMustbeGreaterThanValidation, DefaultValueValidator } from 'src/app/validators/dropdownDefaultValueValidator';

@Component({
  selector: 'app-taskquery',
  templateUrl: './taskquery.component.html',
  styleUrls: ['./taskquery.component.css']
})
export class TaskqueryComponent implements OnInit {


  Model: TaskQueryModel;

  myform: FormGroup;
  taskName: FormControl;
  parentTask: FormControl;
  priorityFormGroup: FormGroup;
  priorityFrom: FormControl;
  priorityTo: FormControl;
  dateFormGroup: FormGroup;
  startDate: FormControl;
  endDate: FormControl;

  @Output()
  SearchObservable: Subject<TaskQueryModel> = new Subject<TaskQueryModel>();

  constructor() { }

  ngOnInit() {
    this.Model = new TaskQueryModel();


    this.taskName = new FormControl(this.Model.TaskName);

    this.priorityFrom = new FormControl(this.Model.PriorityFrom);
    this.priorityTo = new FormControl(this.Model.PriorityTo);
    let numberValidator = NumberMustbeGreaterThanValidation("priorityFrom", "priorityTo");
    this.priorityFormGroup = new FormGroup({ priorityFrom: this.priorityFrom, priorityTo: this.priorityTo })
    this.priorityFormGroup.setValidators(numberValidator);

    this.parentTask = new FormControl(this.Model.ParentTask, [DefaultValueValidator("")]);

    this.startDate = new FormControl(this.Model.StartDate)
    this.endDate = new FormControl(this.Model.EndDate)

    let dateValidator = DateMustbeGreaterThanValidation("startDate", "endDate");
    this.dateFormGroup = new FormGroup({ startDate: this.startDate, endDate: this.endDate });
    this.dateFormGroup.setValidators(dateValidator);

    this.myform = new FormGroup({ taskName: this.taskName, priority: this.priorityFormGroup, parentTask: this.parentTask, dateGroup: this.dateFormGroup });

    this.myform.valueChanges.pipe(
      filter(x => this.myform.valid)
    ).pipe(map(x => {

      this.Model.TaskName=this.taskName.value;
      this.Model.ParentTask=this.parentTask.value;
      this.Model.PriorityFrom=this.priorityFrom.value;
      this.Model.PriorityTo=this.priorityTo.value;
      this.Model.StartDate=this.startDate.value;
      this.Model.EndDate=this.endDate.value;

      return this.Model;
    }))
      .subscribe(x => {
        this.SearchObservable.next(this.Model);
      });
  }

  private search(): void {
    this.SearchObservable.next(this.Model);
  }

}
