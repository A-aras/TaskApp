import { UserModel } from "./user-model";
import { TaskModel } from "./task-model";

export interface ProjectModel {
    projectId : number;
    projectManager     : UserModel;
    projectManagerId? : number ;
    project: string ;
    startDate?     : Date;
    endDate?     : Date;
    priority: number;
    tasks: TaskModel[];
}
