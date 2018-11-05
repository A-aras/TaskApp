import { TaskModel } from '../model/task-model';
import { ProjectModel } from '../model/project-model';
import { ParentTaskModel } from '../model/parent-task-model';
import { UserModel } from '../model/user-model';
import { Observable } from 'rxjs/internal/Observable';


export abstract class IPmApiService {

  abstract getUsers(): Observable<UserModel[]>;
    // abstract getTaskById(id: number): Observable<TaskModel>;
    // abstract queryTasks(query: TaskQueryModel): Observable<TaskModel[]>;
    // abstract getAllParentTask(): Observable<ParentTaskModel[]>;
    abstract AddUser(user: UserModel);
    abstract UpdateUser(user: UserModel):Observable<any>;
    abstract DeleteUser(user: UserModel):Observable<any>;
    //abstract CloseTask(task: TaskModel):Observable<any>;
}
