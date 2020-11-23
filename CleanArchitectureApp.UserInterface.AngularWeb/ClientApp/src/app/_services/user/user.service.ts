import { User } from './../../_models/user.model';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../_models/api-response';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  public userlist: User[] | any;
  constructor(private http: HttpClient) { }

  public getAllUsers(): Observable<User[]>
  {

     return this.http.post<ApiResponse>(`${environment.baseWebApiUrl}/v1/User/GetAllUsers`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.userlist = response.data;
        }
      )
    );

  }

  public getUserById(id: string): Observable<User>
  {

     return this.http.post<ApiResponse>(`${environment.baseWebApiUrl}/v1/User/GetUserById`, {userId: id}).pipe(
      map(
        (response: ApiResponse) => {
          return response.data;
        }
      )
    );

  }

  public createUser(params: any): Observable<User>
  {

     return this.http.post<ApiResponse>(`${environment.baseWebApiUrl}/v1/User/CreateUser`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.data;
        }
      )
    );

  }

  public updateUser(params: any): Observable<User>
  {

     return this.http.put<ApiResponse>(`${environment.baseWebApiUrl}/v1/User/UpdateUserById`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.data;
        }
      )
    );

  }

}
