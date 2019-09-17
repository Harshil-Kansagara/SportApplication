import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Debuger } from '../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

const cmp: string = 'Create Athlete by Test'

@Component({
  templateUrl: 'create-athleteByTest.component.html'
})

export class CreateAthleteByTestComponent implements OnInit {
  pageTitle = "Add new athlete to test";
  id: number;
  formModel = {
    athlete_id: 0,
    distance: 0,
    testId: 0 
  }
  addAthleteModel: string[]=[];
  constructor(private http: HttpClient, private router: Router, private _debug: Debuger,
      private toastr: ToastrService, private activatedRoute: ActivatedRoute) {
    this._debug.loadDebuger(cmp, "Constructor", "Created", []);
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    let promise = this.http.get('/api/AthleteByTest/Create/' + this.id).subscribe(
      (res) => {
        this.addAthleteModel = res as string[];
        this.formModel.testId = this.addAthleteModel['testId'];
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "Get method called", this.addAthleteModel);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribed", this.addAthleteModel);
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('/Coach/AthleteByTest/'+this.id);
  }

  onSubmit() {
    console.log(this.formModel);
    let promise = this.http.post('/api/AthleteByTest/Create/', this.formModel).subscribe(
      res => {
        this.toastr.success("Athlete Added successfully");
        promise.unsubscribe();
        this.router.navigateByUrl('Coach/AthleteByTest/' + this.id);
      }, err => {
        if (err.status == 400) {
          this.toastr.error("Same name already exist. Please delete first.");
        } else {
          console.log(err);
        }
      }
    );
  }

}
