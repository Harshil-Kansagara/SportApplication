import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Debuger } from '../../service/debug.service';

const cmp: string= "Edit Athlete By Test"

@Component({
  templateUrl: './edit-athleteByTest.component.html'
})
export class EditAthleteByTestComponent implements OnInit {
  pageTitle = "Edit Athlete Data";
  id: number;
  athleteId: number;
  editAthleteData: string[] = [];

  formModel = {
    id:0,
    athleteId: 0,
    distance: 0,
    testId: 0
  }

  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService,
    private _debug: Debuger, private activatedRoute: ActivatedRoute) {
    this._debug.loadDebuger(cmp, "Constructor", 'Created', []);
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
      //this.athleteId = params.athleteId;
      this.formModel.athleteId = params.athleteId;
      console.log(this.id + " " + this.formModel.athleteId);
    });
    this.loadData();
  }

  loadData() {
    let promise = this.http.get('api/AthleteByTest/edit/' + this.id + "/" + this.formModel.athleteId).subscribe(
      res => {
        this.editAthleteData = res as string[];
        this.formModel.testId = this.editAthleteData['testId'];
        this.formModel.id = this.editAthleteData['id'];
        this.formModel.distance = this.editAthleteData['distance'];
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "Get method called", this.editAthleteData);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribed", this.editAthleteData);
      }
    );
  }

  onSave() {
    console.log(this.formModel);
    let promise = this.http.post('api/AthleteByTest/edit/', this.formModel).subscribe(
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
      var promise = this.http.delete('api/AthleteByTest/delete/' + this.formModel.id).subscribe(
        (res: any) => {
          this.toastr.success("Athlete data deleted successfully");
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.deleteAthlete.name, "promise unsubscribe", []);
          this.router.navigateByUrl('/Coach/AthleteByTest/' + this.formModel.testId);
        }, err => {
          console.log(err);
        }
      );
    }
  }
}
