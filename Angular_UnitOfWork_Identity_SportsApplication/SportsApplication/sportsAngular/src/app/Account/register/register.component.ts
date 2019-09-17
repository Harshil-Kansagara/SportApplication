import { OnInit, Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Debuger } from 'src/app/service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

const cmp: string = "Register";
@Component({
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  
  formModel = {
    Name: '',
    Email: '',
    Password: '',
    ConfirmPassword: '',
    RoleId: ''
  };

  roleId: string[];
  apiValues: string;

  pageTitle = 'User Register';

  constructor(private httpService: HttpClient, private _debug: Debuger, private toastr: ToastrService, private router: Router) {
    this._debug.loadDebuger(cmp, "constructor","created", []);
  }

  ngOnInit(): void {
   
    var promise=this.httpService.get('api/Account/Register').subscribe
      (data => {
        this.roleId = data as string[];
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "api called using get method", this.roleId);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "unsubscribed", this.roleId);
      });
  }

  onSubmit(form: NgForm) {
    var promise = this.httpService.post('api/Account/Register', form.value).subscribe(
      (result: any) => {
        if (result.succeeded) {
          this._debug.loadDebuger(cmp, this.onSubmit.name, "onSubmit called using post method", form.value);
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.onSubmit.name, "unsubscribed", form.value);
          this.toastr.success('New user created!', 'Registration successful.');
          form.reset();
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
