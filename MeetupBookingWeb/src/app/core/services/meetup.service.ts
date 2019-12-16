import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment.prod";
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from "rxjs";
import { MeetupViewModel } from '../models/meetupViewModel';

@Injectable({
    providedIn: 'root'
})
export class MeetupService {

    controllerUrl: string = environment.apiUrl + '/Meetup';
    
    constructor(private http: HttpClient) {
    }

    getMeetups(): Observable<MeetupViewModel[]> {
        return this.http
            .get<MeetupViewModel[]>(this.controllerUrl);
    };
    
}
