import { NgModule } from '@angular/core'
import { RouterModule, Route,Routes } from '@angular/router';
import { UserDashboardComponent } from 'src/app/user/user-dashboard/user-dashboard.component';



export const RoteConfiguration:Routes=[
    
    //{path:'',component:TaskblotterComponent},
    {path:'AddUser',component:UserDashboardComponent},
    {path:'',redirectTo:'/AddUser',pathMatch:'full'},
    {path:'**',redirectTo:'/AddUser',pathMatch:'full'},
];

@NgModule({
    imports:[RouterModule.forRoot(RoteConfiguration)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}