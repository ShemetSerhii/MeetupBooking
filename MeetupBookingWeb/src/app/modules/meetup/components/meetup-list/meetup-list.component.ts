import { Component, OnInit } from '@angular/core';
import { MeetupService } from 'src/app/core/services/meetup.service';
import { MeetupViewModel } from 'src/app/core/models/meetupViewModel';

@Component({
  selector: 'app-meetup',
  templateUrl: './meetup-list.component.html',
  styleUrls: ['./meetup-list.component.css'],
})

export class MeetupListComponent implements OnInit {

    meetups: MeetupViewModel[];
    meet: MeetupViewModel = new MeetupViewModel();

    constructor(
        private meetupService: MeetupService){}
    

    ngOnInit() {
      this.load();
    }

    load() {
      this.meetupService.getMeetups().subscribe(data => this.meetups = data);
    }

    Show(id: number){
      this.meetupService.getMeetup(id).subscribe(data => this.meet = data);
    }

    Cancel(roomId: number){
        this.meetupService.cancelBooking(roomId, this.meet.id);
        //this.Show(this.meet.id);
    }

}
