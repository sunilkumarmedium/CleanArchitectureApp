import { UserService } from './../../../_services/user/user.service';
import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from 'src/app/_models/user.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  public users: Observable<User[]> | any;

  constructor(private userservice: UserService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  public getAllUsers()
  {
    this.userservice.getAllUsers().subscribe( users => {
      this.users = users;
    });
  }
}
