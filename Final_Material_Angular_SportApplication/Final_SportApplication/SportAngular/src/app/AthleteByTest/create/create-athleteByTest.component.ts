import { Component, OnInit } from '@angular/core';
import { AthleteByTestService } from '../../service/athleteByTest.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Debuger } from '../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { AthleteData } from '../Model/AthleteData';

const cmp: string = 'Create Athlete by Test'

@Component({
  templateUrl: 'create-athleteByTest.component.html'
})

export class CreateAthleteByTestComponent implements OnInit {
  pageTitle = "Add new athlete to test";
  id: number;
  athleteData: AthleteData;
  addAthleteModel: string[] = [];

  constructor(private athleteByTestService: AthleteByTestService, private router: Router, private _debug: Debuger,
    private toastr: ToastrService, private activatedRoute: ActivatedRoute) {
    this._debug.loadDebuger(cmp, "Constructor", "Created", []);
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    this.athleteData = this.athleteByTestService.initializedAthleteData();
    this.loadAthleteList();
  }

  loadAthleteList() {
    let promise = this.athleteByTestService.getAthleteList(this.id).subscribe(
      (res) => {
        this.addAthleteModel = res as string[];
        this.athleteData.testId = this.addAthleteModel['testId'];
        this._debug.loadDebuger(cmp, this.loadAthleteList.name, "Get method called", this.addAthleteModel['testId']);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadAthleteList.name, "promise unsubscribed", this.addAthleteModel);
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('/Coach/AthleteByTest/' + this.id);
  }

  save() {
    let promise = this.athleteByTestService.createAthleteData(this.athleteData).subscribe(
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
