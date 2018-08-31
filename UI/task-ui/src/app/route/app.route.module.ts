import { NgModule } from '@angular/core'
import { RouterModule, Route,Routes } from '@angular/router';
import { TaskblotterComponent } from 'src/app/taskblotter/taskblotter.component';
import { TaskeditorComponent } from 'src/app/taskeditor/taskeditor.component';


const routes:Routes=[
    {path:'',redirectTo:'ViewTask',pathMatch:'full'},
    {path:'ViewTask',component:TaskblotterComponent},
    {path:'EditTask/:id',component:TaskeditorComponent},
    {path:'AddTask',component:TaskeditorComponent}
];

@NgModule({
    imports:[RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}