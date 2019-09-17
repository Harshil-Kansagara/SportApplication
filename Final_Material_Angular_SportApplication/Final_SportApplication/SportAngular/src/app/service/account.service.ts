import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Register } from '../Account/Model/register';
import { Login } from '../Account/Model/login';

@Injectable({ providedIn:'root' })
export class AccountService {

  constructor(private http: HttpClient) {}

  public getAllRoles() {
    return this.http.get('api/Account/Register');
  }

  public registerUser(register: Register) {
    return this.http.post('api/Account/Register', register);
  }

  public loginUser(login: Login) {
    return this.http.post('api/Account/Login', login);
  }
}
