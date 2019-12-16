import { Component, OnInit } from '@angular/core';
import { MeetupService } from 'src/app/core/services/meetup.service';
import { MeetupViewModel } from 'src/app/core/models/meetupViewModel';

@Component({
  selector: 'app-meetup',
  templateUrl: './meetup-list.component.html',
  styleUrls: ['./meetup-list.component.css'],
  providers: [MeetupService]
})

export class MeetupListComponent implements OnInit {

    meetups: MeetupViewModel[];

    constructor(
        private meetupService: MeetupService){}
    

    ngOnInit() {
    }

    load() {
      this.meetupService.getMeetups().subscribe((data => this.meetups = this.meetups));
    }

}
