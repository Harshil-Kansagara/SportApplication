import { Component, OnInit, Inject, ViewChild, AfterViewInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Router } from '@angular/router';
import { Debuger } from '../../service/debug.service';
import { ToastrService } from 'ngx-toastr';
import * as jwt_decode from 'jwt-decode';
import { allAthletesService } from '../../service/allAthletes.service';
import { AthleteList } from '../Model/Athletes';

const cmp: string = "Index All Athletes"

@Component({
  templateUrl: './index-allAthletes.component.html',
  styleUrls: ['./index-allAthletes.component.css']
})

export class IndexAllAthletesComponent implements OnInit, AfterViewInit {

  pageTitle = "All Athletes of ";
  userName: string;
  token: string;
  displayedColumns: string[] = ['AthleteName', 'Id'];
  athleteData: any[];
  athleteList: AthleteList[];
  dataSource = new MatTableDataSource<AthleteList>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private athleteService: allAthletesService, public dialog: MatDialog, private router: Router, private _debug: Debuger, private toastr: ToastrService) {
    this._debug.loadDebuger(cmp, "constructor", "created", []);
  }

  ngOnInit() {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      let decode_token = jwt_decode(this.token);
      this.userName = decode_token['UserName'];
    }
    this.pageTitle = this.pageTitle.concat(this.userName);
    this.loadAthleteList();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  doFilter(value: string){
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  loadAthleteList() {
    var promise = this.athleteService.getAthleteList().subscribe(
      (res) => {
        this.athleteData = res as string[];
        this.athleteList = [];
        this._debug.loadDebuger(cmp, this.loadAthleteList.name, "Method Called", this.athleteData);
        promise.unsubscribe();
        this._debug.loadDebuger(cmp, this.loadAthleteList.name, "unsubscribed", this.athleteData);

        for (let item of this.athleteData) {
          let data = {} as AthleteList;
          data.AthleteName = item['athleteName'];
          data.Id = item['id'];
          this.athleteList.push(data);
        }

        this.dataSource.data = this.athleteList as AthleteList[];

      }
    );
  }

  onBack(): void {
    this.router.navigateByUrl('Coach/TestLists');
  }

  deleteAthlete(id: number): void {
    if (confirm("Are you sure you want to delete ?")) {
      var promise = this.athleteService.deleteAthlete(id).subscribe(
        (res: any) => {
          this.toastr.success("Athlete data is deleted successfully");
          promise.unsubscribe();
          this._debug.loadDebuger(cmp, this.deleteAthlete.name, "promise unsubscribe", []);
          this.loadAthleteList();
        }, err => {
          console.log(err);
        }
      );
    }
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(addAthleteDialogComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != null) {
        var promise = this.athleteService.createAthlete(result).subscribe(
          (res: any) => {
            this._debug.loadDebuger(cmp, this.openAddDialog.name, "OpenAddDialog post method called", res);
            promise.unsubscribe;
            this._debug.loadDebuger(cmp, this.openAddDialog.name, "Unsubscribe", res);
            this.toastr.success("Athlete is created successfully");
            this.loadAthleteList();
          }, err => {
            if (err.status == 400) {
              this.toastr.error('The Athlete name already added. Please delete first!', 'Duplicate Athlete.');
            } else {
              console.log(err);
            }
          })
      } else {
        console.log("No data added");
      }
    });
  }
}

@Component({
  templateUrl: 'addAthlete-dialog.component.html'
})

export class addAthleteDialogComponent {

  constructor(private dialogRef: MatDialogRef<addAthleteDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: AthleteList, private athleteService: allAthletesService) {
    this.data = this.athleteService.initializeAthleteList();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
