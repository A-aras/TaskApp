
import {TaskModel} from "./taskModel"
export class ParentTaskModel{
    ParentTaskId:number;
    Parent_Task:string;
    Tasks:TaskModel[]|null;
}