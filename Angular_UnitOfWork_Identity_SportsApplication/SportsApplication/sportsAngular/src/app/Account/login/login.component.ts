import { OnInit, Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import * as jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';
import { Debuger } from 'src/app/service/debug.service';

const cmp: string= "Login";

@Component({
  templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit {
  formModel = {
    Name:'',
    Password:'',
    RememberMe: false
  };

  pageTitle = 'User Login';

  constructor(private httpService: HttpClient, private _debug: Debuger, private toastr: ToastrService, private router: Router) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit(): void {
    
  }

  onSubmit(form: NgForm) {
    var promise = this.httpService.post('api/Account/Login', form.value).subscribe(
      (res: any) => {
        this._debug.loadDebuger(cmp, this.onSubmit.name, "onSubmit called using post method", res.token);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.onSubmit.name, "unsubscribed", res.token);
        localStorage.setItem('token', res.token);
        form.reset();
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
      //(result: any) => {
      //  if (result.user) {
      //    this._debug.loadDebuger(cmp, this.onSubmit.name, "onSubmit called using post method", form.value);
      //    console.log(form.value);
      //  //  form.reset();
      //  //  this._debug.loadDebuger(cmp, this.onSubmit.name, "onSubmit called using Post Method", form.value);
      //  //  promise.unsubscribe();
      //  //  this._debug.loadDebuger(cmp, this.onSubmit.name, "onSubmit unsubscribe", form.value);
      //  //  if (form.value.RoleId = "d6272412-958c-472d-91d1-d0afd48e7452") {
      //  //    console.log("Coach");
      //  //  }
      //  //  if (form.value.RoleId = "36bf775a-621e-4a6d-92b5-5263da58882c") {
      //  //    console.log("Athlete")
      //  //  }
      //  }
      //}
    );
  }
}
