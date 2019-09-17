import { Component, OnInit } from '@angular/core';
import { Register } from '../Model/register';
import { AccountService } from '../../service/account.service';
import { Debuger } from '../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

const cmp: string = "Register";

@Component({
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']

})

export class RegisterComponent implements OnInit {
  pageTitle = "Register User";
  public currentValue: string = null;

  register = new Register();
  roleId: string[];

  constructor(private accountService: AccountService, private _debug: Debuger, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
    var promise = this.accountService.getAllRoles().subscribe(
      data => {
        this.roleId = data as string[];
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "api called using get method", this.roleId);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "unsubscribed", this.roleId);
      });
  }

  save() {
    var promise = this.accountService.registerUser(this.register).subscribe(
      (result: any) => {
        if (result.succeeded) {
          this._debug.loadDebuger(cmp, this.save.name, "onSubmit called using post method", this.register);
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.save.name, "unsubscribed", this.register);
          this.toastr.success('New user created!', 'Registration successful.');
          this.router.navigateByUrl('/login');
        } else {
          result.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken', 'Registration failed.');
                break;
              default:
                this.toastr.error(element.description, 'Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
