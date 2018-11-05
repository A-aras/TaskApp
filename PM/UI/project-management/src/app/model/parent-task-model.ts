import { TaskModel } from "./task-model";

export interface ParentTaskModel {
    
     parentTaskId: number;
     parent_Task     : string;
     tasks: TaskModel[] ;
}