import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import * as jwt_decode from 'jwt-decode';
import { Debuger } from '../service/debug.service';
import { AthleteDataService } from '../service/athleteData.service';
import { AthleteDetail } from './Model/AthleteDetail';
import { DatePipe } from '@angular/common';
import { MatPaginator, MatTableDataSource, MatSort } from '@angular/material';

const cmp: string = "Athlete Index";

@Component({
  templateUrl: './index-athlete.component.html',
  styleUrls: ['./index-athlete.component.css']
})

export class IndexAthleteComponent implements OnInit, AfterViewInit {
  pageTitle = "Detail of ";
  token: string;
  userName: string;
  athleteDetails: string[];
  athleteData: AthleteDetail[] = [];
  rating: string;
  dataSource = new MatTableDataSource<AthleteDetail>();
  displayedColumns: string[] = ['CoachName', 'Date', 'TestType', 'Distance','Ranking'];

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private _debug: Debuger, private athleteService: AthleteDataService, private datePipe: DatePipe) {
    this._debug.loadDebuger(cmp, "Constructor", "created", [])
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log(this.token, " ", "Token is not null");
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
      this.pageTitle = this.pageTitle.concat(this.userName);
    } else {
      console.log("Token is null");
    }
    this.loadAthleteData();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  doFilter(value: string) {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  loadAthleteData() {
    var promise = this.athleteService.getAthleteData().subscribe(
      (res: any) => {
        this.athleteDetails = res as string[];
        this._debug.loadDebuger(cmp, this.loadAthleteData.name, "Get method called", this.athleteDetails);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadAthleteData.name, "unsubscribed", this.athleteDetails)

        for (let item of this.athleteDetails['athleteByTests']) {
          for (let item1 of this.athleteDetails['testLists']) {
            for (let item2 of this.athleteDetails['coach']) {
              if (item.testId == item1.id && item2.id == item1.coachId) {
                let data = {} as AthleteDetail;
                if (item.athleteDistance > 3500) {
                  this.rating = "Very Good";
                } else if (item.athleteDistance > 2000 && item.athleteDistance <= 3500) {
                  this.rating = "Good";
                } else if (item.athleteDistance > 1000 && item.athleteDistance <= 2000) {
                  this.rating = "Average";
                } else if (item.athleteDistance <= 1000) {
                  this.rating = "Below Average";
                }
                data.CoachName = item2.userName;
                data.Date = this.datePipe.transform(item1.date, 'dd-MM-yyyy');
                data.TestType = item1.testType;
                data.Distance = item.athleteDistance;
                data.Ranking = this.rating;
                this.athleteData.push(data);
              }
            }
          }
        }
        this.dataSource.data = this.athleteData as AthleteDetail[];
      }, err => {
        console.log(err);
      }
    );
  }

}
