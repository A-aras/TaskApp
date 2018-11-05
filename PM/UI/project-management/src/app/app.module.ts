import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import  { DatepickerModule,BsDatepickerModule,ModalModule} from 'ngx-bootstrap'

import { AppComponent } from './app.component';

import { IPmApiService } from './service/pm-api.service-interface';
import { PmApiService } from './service/pm-api.service';
import { UserDashboardComponent } from './user/user-dashboard/user-dashboard.component';
import { ViewUserComponent } from './user/view-user/view-user.component';
import { AddUserComponent } from './user/add-user/add-user.component'
import { AppRoutingModule } from 'src/app/route/app.route.module';


@NgModule({
  declarations: [
    AppComponent,
    UserDashboardComponent,
    ViewUserComponent,
    AddUserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),
    ModalModule.forRoot()
  ],
  providers: [{provide: IPmApiService,useClass:PmApiService}],
  bootstrap: [AppComponent]
})
export class AppModule { }
