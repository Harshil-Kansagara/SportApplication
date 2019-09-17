import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Debuger } from './../../service/debug.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

const cmp = 'Index AthleteByTest';

@Component({
  templateUrl: './index-athleteByTest.component.html'
})

export class IndexAthleteByTestComponent implements OnInit{
  pageTitle: string;
  id: number;
  date: Date;
  athleteByTestDetails: string[] = [];

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
              private http: HttpClient, private debug: Debuger, private toastr: ToastrService,
              private datepipe: DatePipe) {
    this.debug.loadDebuger(cmp, 'Constructor', 'Created', []);
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    this.loadData();
  }

  loadData(): void {
    let promise = this.http.get('api/AthleteByTest/Index/' + this.id).subscribe(res => {
      this.athleteByTestDetails = res as string[];
      this.pageTitle = res['test_type'];
      this.pageTitle = this.pageTitle.concat(" D. ", this.datepipe.transform(res['date'],'dd-MM-yyyy'));
      this.debug.loadDebuger(cmp, this.loadData.name, 'Called get method', this.athleteByTestDetails);
      promise.unsubscribe();
      this.debug.loadDebuger(cmp, this.loadData.name, 'unsubscribe method', this.athleteByTestDetails);
    }, err => {
      if(err.status === 400) {
        this.athleteByTestDetails = [];
        this.toastr.error('No Data found');
      } else {
      console.log(err);
      }
    });
  }

  onBack() {
    this.router.navigateByUrl('Coach/TestLists');
  }

  deleteTest() {
    if (confirm("Are you sure you want to delete " + this.athleteByTestDetails['test_type'])) {
      var promise = this.http.delete('api/TestLists/Delete/' + this.id).subscribe(
        (res: any) => {
          this.toastr.success("Test List deleted successfully");
          promise.unsubscribe();
          this.debug.loadDebuger(cmp, this.deleteTest.name, "promise unsubscribe", []);
          this.router.navigateByUrl('/Coach/TestLists');
        }, err => {
          console.log(err);
        }
      );
    }
  }

  addAthlete() {
    this.router.navigateByUrl('Coach/AthleteByTest/' + this.id + '/create');
  }

  onEdit(athlete_id: string) {
    this.router.navigateByUrl('Coach/AthleteByTest/' + this.id + '/edit/' + athlete_id);
  }
}
