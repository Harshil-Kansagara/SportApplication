import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Debuger } from '../../../service/debug.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import * as jwt_decode from 'jwt-decode';
import { TestList } from '../Model/TestList';
import { TestListService } from '../../../service/testList.service';
import { ConstantPool } from '@angular/compiler';
import { MatPaginator, MatTableDataSource, MatSort } from '@angular/material';

const cmp: string = "TestList";

@Component({
  templateUrl: './index-testList.component.html',
  styleUrls: ['./index-testList.component.css']
})

export class IndexTestListComponent implements OnInit, AfterViewInit {
  pageTitle = "Test List of ";
  token: string;
  userName: string;
  testList: string[];
  testData: TestList[];
  displayedColumns: string[] = ['Date', 'ParticipantNumber', 'TestType', 'Id'];
  dataSource = new MatTableDataSource<TestList>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private _debug: Debuger, private router: Router, private toastr: ToastrService, private tl: TestListService) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
    }
    this.pageTitle = this.pageTitle.concat(this.userName);
    this.loadTestList();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  doFilter (value: string) {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  loadTestList() {
    var promise = this.tl.getTestList().subscribe(
      (res) => {
        this.testList = res as string[];
        this.testData = [];
        this._debug.loadDebuger(cmp, this.loadTestList.name, "Method Called", this.testList);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadTestList.name, "unsubscribed", res);
        for (let item of this.testList) {
          let data = {} as TestList;
          data.Date = item['date'];
          data.ParticipantNumber = item['participantNumber'];
          data.TestType = item['testType'];
          data.Id = item['id'];
          this.testData.push(data);
        }
        console.log(this.testData);
        this.dataSource.data = this.testData as TestList[];
      }
    );
  }

  createTest() {
    this.router.navigateByUrl('Coach/TestLists/create');
  }

  viewAllAthletes() {
    this.router.navigateByUrl('AllAthletes');
  }

  viewAthleteByTest(id: string): void {
    this.router.navigateByUrl('Coach/AthleteByTest/' + id);
  }

  deleteTestData(id: number) {
    if (confirm("Are you sure you want to delete ?")) {
      var promise = this.tl.deleteTest(id).subscribe(
        (res) => {
          this.toastr.success("Test data deleted successfully");
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.deleteTestData.name, "promise unsubscribe", []);
          this.loadTestList();
        }, err => {
          console.log(err);
        }
      );
    }
  }
}
