import {Injectable} from '@angular/core';
import {environment} from "../../../environments/environment.prod";
import {HttpClient} from '@angular/common/http';
import {Observable} from "rxjs";
import {RoomViewModel} from "../models/roomViewModel";

@Injectable({providedIn: 'root'})
export class RoomService {

    controllerUrl: string = environment.apiUrl + '/Room';
    
    constructor(private http: HttpClient) {
    }

    getRooms(): Observable<RoomViewModel[]> {
        return this.http
            .get<RoomViewModel[]>(this.controllerUrl);
    };
    
}