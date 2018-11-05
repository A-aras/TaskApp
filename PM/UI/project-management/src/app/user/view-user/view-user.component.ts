import { Component, OnInit, AfterViewInit, Input } from "@angular/core";

import { Inject } from "@angular/core";
import { switchMap } from "rxjs/internal/operators/switchMap";
import { mergeMap } from "rxjs/internal/operators/mergeMap";
import { filter } from "rxjs/internal/operators/filter";
import { IPmApiService } from "src/app/service/pm-api.service-interface";
import { UserModel } from "src/app/model/user-model";
import { PmServiceBus } from "src/app/service/service_bus";

@Component({
  selector: "app-view-user",
  templateUrl: "./view-user.component.html",
  styleUrls: ["./view-user.component.css"]
})
export class ViewUserComponent implements OnInit, AfterViewInit {
  @Input()
  users: UserModel[];

  ngAfterViewInit(): void {
    //throw new Error("Method not implemented.");
  }

  constructor(
    private service: IPmApiService,
    private serviceBus: PmServiceBus
  ) {}

  ngOnInit() {
    this.loadUserDetails();
    this.serviceBus.UserSearchObservable.subscribe(x => {
      this.loadUserDetails();
    });
  }

  loadUserDetails(): void {
    this.service.getUsers().subscribe(x => {
      this.users = x;
    });
  }

  onEditUser(user:UserModel):void {
    this.serviceBus.UserEditObservable.next(user);
  }

  onDeleteUser(user:UserModel):void {
    this.service.DeleteUser(user).subscribe(x => {
      console.log("User Deleted...");
      //this.router.navigate(["/AddUser"]);
      this.loadUserDetails();
    });
  }
}
