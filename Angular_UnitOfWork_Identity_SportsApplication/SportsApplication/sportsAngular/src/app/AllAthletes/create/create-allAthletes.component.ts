import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Debuger } from 'src/app/service/debug.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

const cmp: string = "Create New Athlete"

@Component({
  templateUrl: './create-allAthletes.component.html'
})

export class CreateAllAthletesComponent implements OnInit {
  pageTitle = "Create New Athlete";
  formModel = {
    athlete_name: ''
  };


  constructor(private _debug: Debuger, private http: HttpClient, private router: Router, private toastr: ToastrService) {
    this._debug.loadDebuger(cmp, "Constructor", "Created", []);
  }

  ngOnInit(): void {

  }

  onSubmit(form: NgForm) {
    var promise = this.http.post('api/AllAthletes/Create', form.value).subscribe(
      (res: any) => {
        this._debug.loadDebuger(cmp, this.onSubmit.name, "OnSubmit post method called", res);
        promise.unsubscribe;
        this._debug.loadDebuger(cmp, this.onSubmit.name, "Unsubscribe", res);
        this.toastr.success("Athlete is created successfully");
        this.onBack();
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('The Athlete name already added. Please delete first!', 'Duplicate Athlete.');
        } else {
          console.log(err);
        }
      }
    )
  }

  onBack() {
    this.router.navigateByUrl('AllAthletes');
  }

}
