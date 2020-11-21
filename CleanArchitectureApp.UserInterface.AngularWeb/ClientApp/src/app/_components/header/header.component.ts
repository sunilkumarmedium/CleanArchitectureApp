import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;

  constructor(
    private authenticationService: AuthenticationService
  ) {

    this.isAuthenticated = this.authenticationService.isAuthenticated();
  }

  ngOnInit(): void {

  }

  logout() {
    this.authenticationService.logout();
}
}
