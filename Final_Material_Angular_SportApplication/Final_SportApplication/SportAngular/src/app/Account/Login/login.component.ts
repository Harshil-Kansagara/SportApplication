import { Component } from '@angular/core';
import { Login } from '../Model/login';
import { Debuger } from '../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { AccountService } from '../../service/account.service';
import * as jwt_decode from 'jwt-decode';

const cmp: string = "Login";

@Component({
  templateUrl: './login.component.html'
})

export class LoginComponent {
  pageTitle = "Login User";

  login = new Login();

  constructor(private _debug: Debuger, private toastr: ToastrService, private router: Router, private accountService: AccountService) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  submit() {
    var promise = this.accountService.loginUser(this.login).subscribe(
      (res: any) => {
        this._debug.loadDebuger(cmp, this.submit.name, "Submit called using post method", res.token);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.submit.name, "unsubscribed", res.token);
        localStorage.setItem('token', res.token);
        let decoded_token = jwt_decode(res.token);
        console.log(decoded_token['UserId'], " ", decoded_token['UserName'], " ", decoded_token['UserRoleId']);
        if (decoded_token['UserRoleId'] == "d6272412-958c-472d-91d1-d0afd48e7452") {
          console.log("coach");
          window.location.href = '/Coach/TestLists';
        } else if (decoded_token['UserRoleId'] == "36bf775a-621e-4a6d-92b5-5263da58882c") {
          console.log("Athlete");
          window.location.href = 'Athlete';
        }
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Incorrect Username or Password.', 'Authentication Failed.');
        } else {
          console.log(err);
        }
      }
    );
  }
}
