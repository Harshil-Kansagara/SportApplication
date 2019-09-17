import { OnInit, Component, ViewChild, AfterViewInit } from '@angular/core';
import { AthleteByTestService } from '../../service/athleteByTest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Debuger } from '../../service/debug.service';
import { DatePipe } from '@angular/common';
import { TestDetail } from '../Model/TestDetail';
import { TestListService } from '../../service/testList.service';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';

const cmp = 'Index AthleteByTest';

@Component({
  templateUrl: './index-athleteByTest.component.html',
  styleUrls: ['./index-athleteByTest.component.css']
})

export class IndexAthleteByTestComponent implements OnInit, AfterViewInit {

  pageTitle: string;
  id: number;
  testDetail: TestDetail[] = [];
  athleteByTestDetails: string[];
  rating: any;
  displayedColumns: string[] = ['athleteName', 'athleteDistance', 'athletePerformance'];
  dataSource = new MatTableDataSource<TestDetail>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private activatedRoute: ActivatedRoute, private router: Router,
    private athleteByTestService: AthleteByTestService, private tlService: TestListService,
    private debug: Debuger, private toastr: ToastrService,
    private datepipe: DatePipe) {
    this.debug.loadDebuger(cmp, 'Constructor', 'Created', []);
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.id = params.id;
    });
    this.loadTestDetail();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  doFilter(value: string){
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  loadTestDetail() {
    let promise = this.athleteByTestService.getTestDetail(this.id).subscribe(res => {
      this.athleteByTestDetails = res as string[];
      this.pageTitle = res['testType'];
      this.pageTitle = this.pageTitle.concat(" D. ", this.datepipe.transform(res['date'], 'dd-MM-yyyy'));
      this.debug.loadDebuger(cmp, this.loadTestDetail.name, 'Called get method', this.athleteByTestDetails);
      promise.unsubscribe();
      this.debug.loadDebuger(cmp, this.loadTestDetail.name, 'unsubscribe method', this.athleteByTestDetails);

      for (let item of this.athleteByTestDetails['athleteList']) {
        for (let item1 of this.athleteByTestDetails['allAthleteLists']) {
          if (item.athleteId === item1.id) {
            let data = {} as TestDetail;
            if (item.athleteDistance > 3500) {
              this.rating= "Very Good";
            } else if (item.athleteDistance > 2000 && item.athleteDistance <= 3500) {
              this.rating = "Good";
            } else if (item.athleteDistance > 1000 && item.athleteDistance <= 2000) {
              this.rating = "Average";
            } else if (item.athleteDistance <= 1000) {
              this.rating = "Below Average";
            }
            data.athleteId = item.athleteId;
            data.athleteName = item1.athleteName;
            data.athleteDistance = item.athleteDistance;
            data.athletePerformance = this.rating;
            this.testDetail.push(data);
          }
        }
      }
      this.dataSource.data = this.testDetail as TestDetail[];
    }, err => {
      if (err.status === 400) {
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
    if (confirm("Are you sure you want to delete " + this.athleteByTestDetails['testType'])) {
      var promise = this.tlService.deleteTest(this.id).subscribe(
        (res: any) => {
          this.toastr.success("Test List deleted successfully");
          promise.unsubscribe();
          this.debug.loadDebuger(cmp, this.deleteTest.name, "promise unsubscribe", []);
          this.loadTestDetail();
        }, err => {
          console.log(err);
        }
      );
    }
  }

  addAthlete() {
    this.router.navigateByUrl('Coach/AthleteByTest/' + this.id + '/create');
  }

  edit(athleteId: string) {
    this.router.navigateByUrl('Coach/AthleteByTest/' + this.id + '/edit/' + athleteId);
  }
}
