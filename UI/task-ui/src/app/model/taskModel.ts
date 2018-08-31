
import { ParentTaskModel } from "./parentTaskModel"
export class TaskModel {
    TaskId: number;
    TaskDescription     : string;
    ParentTaskId: number | null;
    ParentTask: ParentTaskModel | null;
    Priority: Number;
    StartDate     : Date;
    EndDate     : Date;
    IsClosed    : boolean;
}