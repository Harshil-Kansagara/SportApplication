import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Debuger } from 'src/app/service/debug.service';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';

const cmp: string = "Delete Athelte";

@Component({
  templateUrl: './delete-allAthletes.component.html'
})

export class DeleteAllAthletesComponent implements OnInit {
  pageTitle = "Delete Athlete"
  id: string;
  athleteList = {
    athlete_name: ''
  }

  constructor(private router: Router, private _debug: Debuger, private http: HttpClient,
    private activatedRoute: ActivatedRoute, private toastr: ToastrService) {
    this._debug.loadDebuger(cmp, "Constructor", "Created", []);

  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    var promise = this.http.get('api/AllAthletes/Delete/' + this.id).subscribe(
      (res: any) => {
        if (res != null) {
          this.athleteList.athlete_name = res.athlete_name;
          this._debug.loadDebuger(cmp, this.ngOnInit.name, "ngOnInit method call get api", this.athleteList);
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribe", this.athleteList);
        } else {
          this.toastr.error("No Data Found!");
        }
      }
    );
  }

  onBack() {
    this.router.navigateByUrl('AllAthletes');
  }

  onDelete() {
    var promise = this.http.delete('api/AllAthletes/Delete/' + this.id).subscribe(
      (res: any) => {
        this.toastr.success("Athlete is deleted successfully");
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.ngOnInit.name, "promise unsubscribe", []);
        this.router.navigateByUrl('AllAthletes');
      }, err => {
        console.log(err);
      }
    );
  }
}
