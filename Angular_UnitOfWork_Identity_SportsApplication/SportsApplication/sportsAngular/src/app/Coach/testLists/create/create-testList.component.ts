import { Component, OnInit } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { Debuger } from 'src/app/service/debug.service';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import * as jwt_decode from 'jwt-decode';
import { Router } from '@angular/router';

const cmp: string = "Create Test"

@Component({
  templateUrl: './create-testList.component.html'
})

export class CreateTestListComponent implements OnInit {
  date: Date = null;

  formModel = {
    date: '',
    test_type: ''
  }
  testType: string[];
  pageTitle= 'Create Test';

  constructor(private _debug: Debuger, private http: HttpClient, private toastr: ToastrService, private router: Router) {
    this._debug.loadDebuger(cmp, "constructor ", "created", []);
  }

  ngOnInit(): void {
    this.testType = ['Coopertest', '100 meter sprint'];
  }

  onSubmit(form: NgForm) {
    var promise = this.http.post('api/TestLists/Create', form.value).subscribe(
      (res: any) => {
        this._debug.loadDebuger(cmp, this.onSubmit.name, "OnSubmit post method called", res);
        promise.unsubscribe;
        this._debug.loadDebuger(cmp, this.onSubmit.name, "Unsubscribe", res);
        this.toastr.success("Test is created successfully", "Created Test");
        this.router.navigateByUrl('/Coach/TestLists');
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('The test type with same date is already added. Please delete first!', 'Duplicate Test.');
        } else {
          console.log(err);
        }
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('/Coach/TestLists');
  }
}
