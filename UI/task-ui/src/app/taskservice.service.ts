import { Injectable } from '@angular/core';
import { TaskModel } from 'src/app/model/taskModel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ParentTaskModel } from 'src/app/model/parentTaskModel';
import { of } from 'rxjs';
import { TaskQueryModel } from 'src/app/model/taskQueryModel';
import { HttpHeaders } from '@angular/common/http';
import { URLSearchParams } from 'url';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaskserviceService {

  constructor(private httpService: HttpClient) { }

  // getAllTask(): Observable<any> {
  //   return this.httpService.get("http://localhost:52537/api/task");
  // }

  getAllTask(): Observable<TaskModel[]> {

    return this.httpService.get<TaskModel[]>("http://localhost:52537/api/task/GetAllTask");

  }

  getTaskById(id:number): Observable<TaskModel> {

    return this.httpService.get<TaskModel>("http://localhost:52537/api/task/GetTaskById/"+id);

  }

  queryTasks(query: TaskQueryModel): Observable<TaskModel[]> {
    let header = new HttpHeaders();
    let params=new HttpParams();
    params=params.append("TaskName",query.TaskName);

    //let body=new HttpBody();

    let requestOptions={headers:header,params:params};
    return this.httpService.get<TaskModel[]>("http://localhost:52537/api/task/QueryTaks",requestOptions);

  }

  getAllParentTask(): Observable<ParentTaskModel[]> {

    //return of(this.parentTask);
    // return this.parentTask..    this.parentTask.aso
    return this.httpService.get<ParentTaskModel[]>("http://localhost:52537/api/task/GetAllParentTask");

  }

  AddTaks(task: TaskModel) {

    return this.httpService.post("http://localhost:52537/api/task", task);
  }

  private task: TaskModel[] = [
    { TaskId: 1, TaskDescription: "Task 1", ParentTaskId: 1, ParentTask: { ParentTaskId: 1, Parent_Task: "Parent Task1", Tasks: null }, Priority: 1, StartDate: new Date(2018, 5, 5), EndDate: new Date(2018, 5, 5),IsClosed:false }
  ];

  private parentTask: ParentTaskModel[] = [
    { ParentTaskId: 1, Parent_Task: "Parent Task1", Tasks: null }, { ParentTaskId: 2, Parent_Task: "Parent Task2", Tasks: null },
  ];
}
