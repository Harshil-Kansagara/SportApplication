import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class AthleteDataService {

  constructor(private http: HttpClient) { }

  getAthleteData() {
    return this.http.get('api/AthleteDetails/Index');
  }
}
