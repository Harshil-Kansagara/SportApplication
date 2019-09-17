import { Component, OnInit } from '@angular/core';
import { AthleteByTestService } from '../../service/athleteByTest.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Debuger } from '../../service/debug.service';
import { AthleteData } from '../Model/AthleteData';

const cmp: string = "Edit Athlete By Test"

@Component({
  templateUrl: './edit-athleteByTest.component.html'
})

export class EditAthleteByTestComponent implements OnInit {
  pageTitle = "Edit Athlete Data";
  id: number;
  athleteId: number;
  editAthleteData: string[] = [];
  athleteData: AthleteData;

  constructor(private athleteTestService: AthleteByTestService, private router: Router, private toastr: ToastrService,
    private _debug: Debuger, private activatedRoute: ActivatedRoute) {
    this._debug.loadDebuger(cmp, "Constructor", 'Created', []);
  }

  ngOnInit() {
    this.athleteData = this.athleteTestService.initializedAthleteData();
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
      this.athleteData.athleteId = params.athleteId;
    });
    this.loadData();
  }

  loadData() {
    let promise = this.athleteTestService.getAthleteData(this.id, this.athleteData.athleteId).subscribe(
      res => {
        this.editAthleteData = res as string[];
        this.athleteData.testId = this.editAthleteData['testId'];
        this.athleteData.id = this.editAthleteData['id'];
        this.athleteData.distance = this.editAthleteData['distance'];
        this._debug.loadDebuger(cmp, this.loadData.name, "Get method called", this.editAthleteData);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadData.name, "promise unsubscribed", this.editAthleteData);
      }
    );
  }

  save() {
    console.log(this.athleteData);
    let promise = this.athleteTestService.editAthleteData(this.athleteData).subscribe(
      res => {
        this.toastr.success("Athlete Data Update successfully");
        promise.unsubscribe();
        this.router.navigateByUrl('Coach/AthleteByTest/' + this.id);
      }, err => {
        console.log(err);
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('/Coach/AthleteByTest/' + this.id);
  }

  deleteAthlete() {
    if (confirm("Are you sure you want to delete ?")) {
      var promise = this.athleteTestService.deleteAthleteData(this.athleteData.id).subscribe(
        (res: any) => {
          this.toastr.success("Athlete data deleted successfully");
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.deleteAthlete.name, "promise unsubscribe", []);
          this.router.navigateByUrl('/Coach/AthleteByTest/' + this.athleteData.testId);
        }, err => {
          console.log(err);
        }
      );
    }
  }
}
