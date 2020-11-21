import { Component } from '@angular/core';
import { User } from './_models/user.model';
import { AuthenticationService } from './_services/authentication/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CleanArchitectureApp';
  user!: User | null;
  constructor(private authenticationService: AuthenticationService) {
    this.authenticationService.user.subscribe(x => this.user = x);
}


}
