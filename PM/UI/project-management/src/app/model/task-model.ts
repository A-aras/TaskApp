import { ParentTaskModel } from "./parent-task-model";
import { ProjectModel } from "./project-model";
import { UserModel } from "./user-model";


export interface TaskModel {
    taskId : number;
    parentTask?     : ParentTaskModel;
    parentTaskId? : number ;
    taskDescription: string ;
    startDate?     : Date;
    endDate?     : Date;
    priority: number;
    isClosed     : boolean;
    projectId: number;
    project: ProjectModel;
    userId: number;
    user: UserModel;
    
}
